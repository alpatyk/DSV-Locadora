using System.ComponentModel.DataAnnotations;

namespace Locadora.Models;

public class Filme
{
    [Key]
    private int _filmeId;
    private string? _titulo;
    private string _descricao;
    private string? _genero;
    private float _preco;
    

    [Key]
    public int filmeId
    {
        get => _filmeId;
        set => _filmeId = value;
    }

    public string? titulo
    {
        get => _titulo;
        set => _titulo = value;
    }

    public string descricao
    {
        get => _descricao;
        set => _descricao = value;
    }

    public string? genero
    {
        get => _genero;
        set => _genero = value;
    }

    public string? preco
    {
        get => _preco;
        set => _preco = value;
    }

}
