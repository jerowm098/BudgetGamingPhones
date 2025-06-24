namespace InfinixShop_Desktop
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// the contents of this method with the code editor.
        private void InitializeComponent()
        {
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.btnNoThanks = new System.Windows.Forms.Button();
            this.btnViewShop = new System.Windows.Forms.Button();
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.btnExitApp = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageShop = new System.Windows.Forms.TabPage();
            this.btnAddSelectedToCart = new System.Windows.Forms.Button();
            this.lbAvailablePhones = new System.Windows.Forms.ListBox();
            this.lblAvailablePhones = new System.Windows.Forms.Label();
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.lblCategories = new System.Windows.Forms.Label();
            this.tabPageCart = new System.Windows.Forms.TabPage();
            this.btnRemoveSelectedFromCart = new System.Windows.Forms.Button();
            this.lbCartItems = new System.Windows.Forms.ListBox();
            this.lblCartItems = new System.Windows.Forms.Label();
            this.pnlWelcome.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageShop.SuspendLayout();
            this.tabPageCart.SuspendLayout();
            this.SuspendLayout();
            
            // pnlWelcome
            
            this.pnlWelcome.Controls.Add(this.btnNoThanks);
            this.pnlWelcome.Controls.Add(this.btnViewShop);
            this.pnlWelcome.Controls.Add(this.lblWelcomeMessage);
            this.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWelcome.Location = new System.Drawing.Point(0, 0);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(800, 450);
            this.pnlWelcome.TabIndex = 0;
            
            // btnNoThanks
            
            this.btnNoThanks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNoThanks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNoThanks.Location = new System.Drawing.Point(400, 250);
            this.btnNoThanks.Name = "btnNoThanks";
            this.btnNoThanks.Size = new System.Drawing.Size(150, 50);
            this.btnNoThanks.TabIndex = 2;
            this.btnNoThanks.Text = "No Thanks";
            this.btnNoThanks.UseVisualStyleBackColor = true;
            this.btnNoThanks.Click += new System.EventHandler(this.btnNoThanks_Click);
            
            // btnViewShop
            
            this.btnViewShop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewShop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnViewShop.Location = new System.Drawing.Point(250, 250);
            this.btnViewShop.Name = "btnViewShop";
            this.btnViewShop.Size = new System.Drawing.Size(150, 50);
            this.btnViewShop.TabIndex = 1;
            this.btnViewShop.Text = "View Shop";
            this.btnViewShop.UseVisualStyleBackColor = true;
            this.btnViewShop.Click += new System.EventHandler(this.btnViewShop_Click);
            
            // lblWelcomeMessage
            
            this.lblWelcomeMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcomeMessage.AutoSize = true;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcomeMessage.Location = new System.Drawing.Point(180, 150);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Size = new System.Drawing.Size(462, 41);
            this.lblWelcomeMessage.TabIndex = 0;
            this.lblWelcomeMessage.Text = "Wanna take a look at our Latest Products?";
            this.lblWelcomeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // pnlMainContent
            
            this.pnlMainContent.Controls.Add(this.btnExitApp);
            this.pnlMainContent.Controls.Add(this.tabControlMain);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(800, 450);
            this.pnlMainContent.TabIndex = 1;
            this.pnlMainContent.Visible = false; // Initially hidden
            
            // btnExitApp
            
            this.btnExitApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitApp.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExitApp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExitApp.Location = new System.Drawing.Point(650, 390);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(138, 48);
            this.btnExitApp.TabIndex = 1;
            this.btnExitApp.Text = "Exit App";
            this.btnExitApp.UseVisualStyleBackColor = false;
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            
            // tabControlMain
            
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageShop);
            this.tabControlMain.Controls.Add(this.tabPageCart);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(776, 372);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            
            // tabPageShop
            
            this.tabPageShop.Controls.Add(this.btnAddSelectedToCart);
            this.tabPageShop.Controls.Add(this.lbAvailablePhones);
            this.tabPageShop.Controls.Add(this.lblAvailablePhones);
            this.tabPageShop.Controls.Add(this.lbCategories);
            this.tabPageShop.Controls.Add(this.lblCategories);
            this.tabPageShop.Location = new System.Drawing.Point(4, 29);
            this.tabPageShop.Name = "tabPageShop";
            this.tabPageShop.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShop.Size = new System.Drawing.Size(768, 339);
            this.tabPageShop.TabIndex = 0;
            this.tabPageShop.Text = "Shop";
            this.tabPageShop.UseVisualStyleBackColor = true;
            
            // btnAddSelectedToCart
            
            this.btnAddSelectedToCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSelectedToCart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddSelectedToCart.Location = new System.Drawing.Point(544, 282);
            this.btnAddSelectedToCart.Name = "btnAddSelectedToCart";
            this.btnAddSelectedToCart.Size = new System.Drawing.Size(200, 48);
            this.btnAddSelectedToCart.TabIndex = 4;
            this.btnAddSelectedToCart.Text = "Add Selected to Cart";
            this.btnAddSelectedToCart.UseVisualStyleBackColor = false;
            this.btnAddSelectedToCart.Click += new System.EventHandler(this.btnAddSelectedToCart_Click);
            
            // lbAvailablePhones
            
            this.lbAvailablePhones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAvailablePhones.FormattingEnabled = true;
            this.lbAvailablePhones.ItemHeight = 20;
            this.lbAvailablePhones.Location = new System.Drawing.Point(260, 40);
            this.lbAvailablePhones.Name = "lbAvailablePhones";
            this.lbAvailablePhones.Size = new System.Drawing.Size(484, 224);
            this.lbAvailablePhones.TabIndex = 3;
            
            // lblAvailablePhones
            
            this.lblAvailablePhones.AutoSize = true;
            this.lblAvailablePhones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvailablePhones.Location = new System.Drawing.Point(260, 14);
            this.lblAvailablePhones.Name = "lblAvailablePhones";
            this.lblAvailablePhones.Size = new System.Drawing.Size(147, 23);
            this.lblAvailablePhones.TabIndex = 2;
            this.lblAvailablePhones.Text = "Available Phones:";
            
            // lbCategories
            
            this.lbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.ItemHeight = 20;
            this.lbCategories.Location = new System.Drawing.Point(19, 40);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.Size = new System.Drawing.Size(220, 224);
            this.lbCategories.TabIndex = 1;
            this.lbCategories.SelectedIndexChanged += new System.EventHandler(this.lbCategories_SelectedIndexChanged);
            
            // lblCategories
            
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCategories.Location = new System.Drawing.Point(19, 14);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(148, 23);
            this.lblCategories.TabIndex = 0;
            this.lblCategories.Text = "Phone Categories:";
            
            // tabPageCart
            
            this.tabPageCart.Controls.Add(this.btnRemoveSelectedFromCart);
            this.tabPageCart.Controls.Add(this.lbCartItems);
            this.tabPageCart.Controls.Add(this.lblCartItems);
            this.tabPageCart.Location = new System.Drawing.Point(4, 29);
            this.tabPageCart.Name = "tabPageCart";
            this.tabPageCart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCart.Size = new System.Drawing.Size(768, 339);
            this.tabPageCart.TabIndex = 1;
            this.tabPageCart.Text = "Cart";
            this.tabPageCart.UseVisualStyleBackColor = true;
            
            // btnRemoveSelectedFromCart
            
            this.btnRemoveSelectedFromCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSelectedFromCart.BackColor = System.Drawing.Color.LightCoral;
            this.btnRemoveSelectedFromCart.Location = new System.Drawing.Point(513, 282);
            this.btnRemoveSelectedFromCart.Name = "btnRemoveSelectedFromCart";
            this.btnRemoveSelectedFromCart.Size = new System.Drawing.Size(232, 48);
            this.btnRemoveSelectedFromCart.TabIndex = 2;
            this.btnRemoveSelectedFromCart.Text = "Remove Selected from Cart";
            this.btnRemoveSelectedFromCart.UseVisualStyleBackColor = false;
            this.btnRemoveSelectedFromCart.Click += new System.EventHandler(this.btnRemoveSelectedFromCart_Click);
            
            // lbCartItems
            
            this.lbCartItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCartItems.FormattingEnabled = true;
            this.lbCartItems.ItemHeight = 20;
            this.lbCartItems.Location = new System.Drawing.Point(23, 40);
            this.lbCartItems.Name = "lbCartItems";
            this.lbCartItems.Size = new System.Drawing.Size(722, 224);
            this.lbCartItems.TabIndex = 1;
            
            // lblCartItems
            
            this.lblCartItems.AutoSize = true;
            this.lblCartItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCartItems.Location = new System.Drawing.Point(23, 14);
            this.lblCartItems.Name = "lblCartItems";
            this.lblCartItems.Size = new System.Drawing.Size(99, 23);
            this.lblCartItems.TabIndex = 0;
            this.lblCartItems.Text = "Your Cart: ";
            
            // frmMain
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlWelcome);
            this.Name = "frmMain";
            this.Text = "Infinix Shop Desktop";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageShop.ResumeLayout(false);
            this.tabPageShop.PerformLayout();
            this.tabPageCart.ResumeLayout(false);
            this.tabPageCart.PerformLayout();
            this.ResumeLayout(false);

        }


        private Panel pnlWelcome;
        private Button btnNoThanks;
        private Button btnViewShop;
        private Label lblWelcomeMessage;
        private Panel pnlMainContent;
        private TabControl tabControlMain;
        private TabPage tabPageShop;
        private Button btnAddSelectedToCart;
        private ListBox lbAvailablePhones;
        private Label lblAvailablePhones;
        private ListBox lbCategories;
        private Label lblCategories;
        private TabPage tabPageCart;
        private Button btnRemoveSelectedFromCart;
        private ListBox lbCartItems;
        private Label lblCartItems;
        private Button btnExitApp;
    }
}
