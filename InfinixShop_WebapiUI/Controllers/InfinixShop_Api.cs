using Microsoft.AspNetCore.Mvc;
using InfinixShop_BusinessLogic;
using InfinixShop_Common;
using System.Collections.Generic;

// namespace for API project
namespace InfinixShop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfinixShop_Api : ControllerBase
    {
        [HttpGet("Get Items")]
        public ActionResult<IEnumerable<PhoneItem>> GetCart()
        {
            var cartItems = InfinixShopLogic.GetAllItemsInCart();
            return Ok(cartItems);
        }

        [HttpPost("Add Items")]
        public ActionResult<PhoneItem> AddPhone([FromBody] PhoneItem request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
            {
                return BadRequest("Phone name cannot be empty.");
            }

            var addedItem = InfinixShopLogic.AddToCart(request.Name);
            if (addedItem != null)
            {
                return CreatedAtAction(nameof(SearchPhone), new { name = addedItem.Name }, addedItem);
            }
            else
            {
                return Conflict("A phone with this name already exists in the cart or failed to add.");
            }
        }

        [HttpDelete("Remove Item")]
        public ActionResult<PhoneItem> RemovePhone([FromQuery] string phoneName)
        {
            if (string.IsNullOrEmpty(phoneName))
            {
                return BadRequest("Phone name to remove cannot be empty.");
            }
            var removedItem = InfinixShopLogic.RemoveFromCart(phoneName);
            if (removedItem != null)
            {
                return Ok(removedItem);
            }
            else
            {
                return NotFound("Phone not found in the cart.");
            }
        }

        [HttpGet("Search Item")]
        public ActionResult<PhoneItem> SearchPhone([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Search name cannot be empty.");
            }
            var phoneItem = InfinixShopLogic.SearchPhoneByName(name);

            if (phoneItem == null)
            {
                return NotFound("Phone not found.");
            }
            return Ok(phoneItem);
        }

        [HttpPatch("Update Item")]
        public ActionResult<PhoneItem> UpdatePhoneName(int id, [FromBody] string newName)
        {
            if (string.IsNullOrEmpty(newName))
            {
                return BadRequest("New name cannot be empty.");
            }
            var updatedItem = InfinixShopLogic.UpdatePhoneName(id, newName);
            if (updatedItem != null)
            {
                return Ok(updatedItem);
            }
            else
            {
                return NotFound("Phone not found or update failed (e.g., new name already exists).");
            }
        }
    }
}