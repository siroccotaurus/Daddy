using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragonsWeb.Models.Responses
{
    public class UserResponse : BaseResponse {
        public UserResponse() : base() { }
        public UserResponse(bool s) : base(s) { }
        public UserResponse(bool s, string m) : base(s, m) { }
        public UserResponse(bool s, object d) : base(s, d) { }
        public UserResponse(bool s, string m, object d) : base(s, m, d) { }
    }
}
