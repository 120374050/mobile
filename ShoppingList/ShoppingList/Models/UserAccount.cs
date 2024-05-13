using System;
namespace ShoppingList.Models
{
	public class UserAccount
	{
		public string username { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string userKey { get; set; }

		public UserAccount(string username, string email, string password)
		{
			this.username = username;
			this.email = email;
			this.password = password;
		}

        public UserAccount(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public UserAccount(string userKey)
        {
			this.userKey = userKey;
        }
    }
}

