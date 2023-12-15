using Catalogo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Entities;

public sealed class Categoria
{
    public Categoria(string nome, string imagemUrl)
    {
        ValidateDomain(0, nome, imagemUrl);
    }

    public Categoria(int id, string nome, string imagemUrl)
    {
        ValidateDomain(id, nome, imagemUrl);
    }

    public int Id { get; set; }
    public string Nome { get; private set; }
    public string ImagemUrl { get; private set; }
    public ICollection<Produto> Produtos { get; set; }

    private void ValidateDomain(int id, string nome, string imagemUrl)
    {
        DomainExceptionValidation.When(id < 0, "valor de Id inválido.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido. O nome é obrigatório");

        DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl),
            "Nome da imagem inválido. O nome é obrigatório");

        DomainExceptionValidation.When(nome.Length < 3,
           "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(imagemUrl.Length < 5,
            "Nome da imagem deve ter no mínimo 5 caracteres");

        Id = id;
        Nome = nome;
        ImagemUrl = imagemUrl;
    }
}
