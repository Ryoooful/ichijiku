
namespace api.Models
{
    public class LoginUserModel
    {
        public string user_id { get; set; } = "unknown";
        public string? user_name { get; set; }
        public bool administrator { get; set; } = false;
        public bool leader { get; set; } = false;
        public bool closer { get; set; } = false;
        public bool staff { get; set; } = false;
        public bool client { get; set; } = false;
    }
}
