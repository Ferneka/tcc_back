using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Api.Application.Models.ViewModels.Extensions;

public static class ComissaoViewModelExtension
{
    public static ComissaoViewModel ToViewModel(this ComissaoDto dto)
    {
        return new ComissaoViewModel { Id = dto.Id, IdTipoComissao = dto.IdTipoComissao };
    }
}
