using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JogosController.Controllers;
[ApiController]
[Route("[controller]")]
public class JogosController : ControllerBase
{
    private LocadoraDbContext _dbContext;
    public JogosController(LocadoraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Jogos jogos)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Jogos is null) return NotFound();
        await _dbContext.AddAsync(jogos);
        await _dbContext.SaveChangesAsync();
        return Created("", jogos);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Jogos>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Jogos is null) return NotFound();
        return await _dbContext.Jogos.ToListAsync();
    }

    [HttpDelete()]
    [Route("excluir/{jogoId}")]
    public async Task<ActionResult> Excluir(int jogoId)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Jogos is null) return NotFound();
        var jogoTemp = await _dbContext.Jogos.FindAsync(jogoId);
        if(jogoTemp is null) return NotFound();
        _dbContext.Remove(jogoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}