using System.Threading.Tasks;
using Pcb.Dto.Reference;

namespace Pcb.Service.Interfaces
{
	/// <summary>
	/// The Reference Command Service Interface
	/// </summary>
	public interface IReferenceCommandService
	{
		/// <summary>
		/// Saves a reference item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		Task Save(IReferenceItemFull item);
	}
}
