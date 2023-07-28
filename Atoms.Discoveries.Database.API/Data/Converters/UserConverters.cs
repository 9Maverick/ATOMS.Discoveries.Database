using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class UserConverters
{
	public static UserDTO UserToDTO(User user)
	{
		return new UserDTO
		{
			Id = user.Id,
			NickName = user.NickName
		};
	}
}
