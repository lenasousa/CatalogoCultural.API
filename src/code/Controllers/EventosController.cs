using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoCultural.API.Data;
using CatalogoCultural.API.Models;
using CatalogoCultural.API.ViewModels;

namespace CatalogoCultural.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Construtor do controller de eventos. Ele recebe uma instância do AppDbContext para acessar o banco de dados.
        /// Dentro do construtor, há uma verificação para garantir que, caso o banco de dados esteja vazio, um evento de exemplo seja adicionado. Isso é útil para fins de desenvolvimento e testes, garantindo que haja dados disponíveis para serem retornados nas requisições GET.
        /// </summary>
        /// <param name="context"></param>
        public EventosController(AppDbContext context)
        {
            _context = context;
            
            // Aqui os dados ficam mockandos, caso o banco em memória esteja vazio.
            if (!_context.Eventos.Any())
            {
                _context.Eventos.Add(new Evento
                {
                    Nome = "Virada Cultural Mockada",
                    Tipo = "Festival",
                    Bairro = "Centro",
                    Endereco = "Vários locais",
                    Descricao = "Maior evento cultural gratuito.",
                    Zona = "Central",
                    Gratuito = true,
                    Valor = "R$ 00,00",
                    Data = "2026-06-20",
                    Destaques = new List<string> { "Show principal", "Palco de Teatro" }
                });
                _context.SaveChanges();
            }
        }

        // GET: api/eventos
        /// <summary>
        /// Retorna a lista de eventos culturais cadastrados no sistema.
        /// Cada evento é transformado em um EventoViewModel para ser enviado ao frontend, garantindo que apenas os dados necessários sejam expostos.
        /// </summary>
        /// <returns>
        /// Uma lista de objetos EventoViewModel representando os eventos culturais disponíveis.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoViewModel>>> GetEventos()
        {
            var eventos = await _context.Eventos.ToListAsync();

            // Transformando o Model (Banco) no ViewModel (Frontend)
            var eventosViewModel = eventos.Select(e => new EventoViewModel
            {
                Id = e.Id,
                Nome = e.Nome,
                Tipo = e.Tipo,
                Bairro = e.Bairro,
                Endereco = e.Endereco,
                Descricao = e.Descricao,
                Zona = e.Zona,
                Gratuito = e.Gratuito,
                Valor = e.Valor,
                Data = e.Data,
                Imagem = e.Imagem,
                Site = e.Site,
                Destaques = e.Destaques
            }).ToList();

            return Ok(eventosViewModel);
        }
    }
}