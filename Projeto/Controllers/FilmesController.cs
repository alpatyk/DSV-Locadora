using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesController.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{
    private LocadoraDbContext _dbContext;
    public FilmesController(LocadoraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Filmes filmes)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Filmes is null) return NotFound();
        await _dbContext.AddAsync(filmes);
        await _dbContext.SaveChangesAsync();
        return Created("", filmes);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Filmes>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Filmes is null) return NotFound();
        return await _dbContext.Filmes.ToListAsync();
    }

    [HttpDelete()]
    [Route("excluir/{jogoId}")]
    public async Task<ActionResult> Excluir(int filmeId)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Filmes is null) return NotFound();
        var filmeTemp = await _dbContext.Filmes.FindAsync(filmeId);
        if(filmeTemp is null) return NotFound();
        _dbContext.Remove(filmeTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}