using System.ComponentModel.DataAnnotations;

namespace Locadora.Models;

public class Jogos
{
    [Key]
    private int _jogoId;
    private string? _titulo;
    private string _descricao;
    private string? _genero;
    private float _preco;
    

    [Key]
    public int jogoId
    {
        get => _jogoId;
        set => _jogoId = value;
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
