namespace Autoberles.Model {
    internal class User {
        int id;
        string username;
        string password;
        string email;
        string address;
        string phone;
        string role;
        bool isActive;

        public User(int id, string username, string password, string email, string address, string phone, string role, bool isActive) {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Address = address;
            this.Phone = phone;
            this.Role = role;
            this.IsActive = isActive;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Role { get => role; set => role = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}
