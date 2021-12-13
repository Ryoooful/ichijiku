
namespace api.Models
{
    public class LoginUserModel
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public bool administrator { get; set; }
        public bool leader { get; set; }
        public bool closer { get; set; }
        public bool staff { get; set; }
        public bool client { get; set; }
    }
}
