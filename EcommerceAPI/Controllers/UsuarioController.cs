using Microsoft.AspNetCore.Mvc;
using EcommerceAPI.Models;
using EcommerceAPI.Data;

public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;
    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/usuarios
    [HttpGet]
    public IActionResult GetUsuarios()
    {
        return Ok(_context.Usuarios.ToList());
    }

    // GET: api/usuarios/{id}
    [HttpGet("{id}")]
    public IActionResult GetUsuario(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    //Post: api/usuarios
    [HttpPost]
    public IActionResult CreateUsuario([FromBody] Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id}, usuario);
    }

    // PUT: api/usuarios/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUsurio(int id, [FromBody] Usuario usuario)
    {
        var usuarioExistente = _context.Usuarios.Find(id);
        if (usuarioExistente == null) return NotFound();

        usuarioExistente.Nome = usuario.Nome;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Senha = usuario.Senha;

        _context.SaveChanges();
        return NoContent();
    }

    // DELETE api/usuarios/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUsuario(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null) return NotFound();

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
        return NoContent();
    }
}