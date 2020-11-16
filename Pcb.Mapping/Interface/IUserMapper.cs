using Pcb.Database.Context.Models;
using Pcb.Dto.School;
using Pcb.Dto.Security;
using Pcb.Dto.User;
using System.Collections.Generic;

namespace Pcb.Mapping.Interface
{
	public interface IUserMapper
	{
		User MapRegisterUserProfileDtoToUser(RegisterUserDto userDto);

		UserProfileDto MapUserToUserProfileDto(User map);
		List<UserRoleDto> MapUserRoleToUserRoleDto(IEnumerable<UserRole> map);
		SchoolDto MapSchoolToSchoolDto(School map);
		RoleDto MapRoleToRoleDto(Role map);
	}
}
