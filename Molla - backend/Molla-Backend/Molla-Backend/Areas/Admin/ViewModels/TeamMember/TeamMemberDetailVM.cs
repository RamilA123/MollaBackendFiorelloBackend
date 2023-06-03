using System;
namespace Molla_Backend.Areas.Admin.ViewModels.TeamMember
{
	public class TeamMemberDetailVM
	{
        public string Image { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Info { get; set; }
        public bool Status { get; set; }
        public string CreateDate { get; set; }
    }
}

