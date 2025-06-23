using Microsoft.AspNetCore.Mvc;
using InfinixShop_BusinessLogic;
using InfinixShop_Common;
using System.Collections.Generic;

// The namespace for your API project
namespace InfinixShop_Api.Controllers
{
    [Route("api/[controller]")] // [controller] will automatically resolve to InfinixShop_Api
    [ApiController]
    public class InfinixShop_Api : ControllerBase
    {
        /// Retrieves all items currently in the shopping cart.
        [HttpGet] // Maps to GET /api/InfinixShop_Api
        public ActionResult<IEnumerable<PhoneItem>> GetCart()
        {
            var cartItems = InfinixShopLogic.GetAllItemsInCart();
            return Ok(cartItems);
        }

        /// Adds a new phone item to the shopping cart.
        /// <param name="request">
        [HttpPost] // Maps to POST /api/InfinixShop_Api
        public ActionResult<bool> AddPhone([FromBody] PhoneItem request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
            {
                return BadRequest(false);
            }

            var result = InfinixShopLogic.AddToCart(request.Name);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return Conflict(false);
            }
        }
        /// Removes a phone item from the shopping cart.
        /// <param name="phoneName">
        [HttpDelete] // Maps to DELETE /api/InfinixShop_Api
        public ActionResult<bool> RemovePhone([FromQuery] string phoneName)
        {
            if (string.IsNullOrEmpty(phoneName))
            {
                return BadRequest(false);
            }

            var result = InfinixShopLogic.RemoveFromCart(phoneName);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }
        /// Searches for a phone item by name in the cart.
        /// <param name="name">
        [HttpGet("search")] // Maps to GET /api/InfinixShop_Api/search
        public ActionResult<PhoneItem> SearchPhone([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Search name cannot be empty.");
            }
            var phoneItem = InfinixShopLogic.SearchPhoneByName(name);

            if (phoneItem == null)
            {
                return NotFound();
            }
            return Ok(phoneItem);
        }
    }
}
