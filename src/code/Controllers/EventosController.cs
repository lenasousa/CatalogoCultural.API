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

        // POST: api/eventos
        /// <summary>
        /// Adiciona um novo evento cultural ao sistema. O evento é recebido como um objeto EventoViewModel no corpo da requisição, que é então convertido para o modelo de dados Evento antes de ser salvo no banco de dados.
        /// Após a criação do evento, o método retorna um status 201 (Created) junto com os dados do evento criado, incluindo o ID gerado pelo banco de dados. Se os dados do evento forem inválidos (por exemplo, se o corpo da requisição estiver vazio), o método retorna um status 400 (Bad Request) com uma mensagem de erro.
        /// </summary>
        /// <param name="novoEventoDto"></param>
        /// <returns>
        /// Um objeto EventoViewModel representando o evento criado, incluindo o ID gerado pelo banco de dados. Em caso de erro, retorna uma mensagem de erro explicando o motivo do problema.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<EventoViewModel>> PostEvento([FromBody] EventoViewModel novoEventoDto)
        {
            if (novoEventoDto == null)
            {
                return BadRequest("Os dados do evento são inválidos.");
            }

            // Convertendo a ViewModel recebida do Angular para o Model do Banco de Dados
            var novoEvento = new Evento
            {
                Nome = novoEventoDto.Nome ?? string.Empty,
                Tipo = novoEventoDto.Tipo ?? string.Empty,
                Bairro = novoEventoDto.Bairro ?? string.Empty,
                Endereco = novoEventoDto.Endereco ?? string.Empty,
                Descricao = novoEventoDto.Descricao ?? string.Empty,
                Zona = novoEventoDto.Zona ?? string.Empty,
                Gratuito = novoEventoDto.Gratuito,
                Valor = novoEventoDto.Valor ?? "R$ 00,00",
                Data = novoEventoDto.Data ?? string.Empty,
                Imagem = novoEventoDto.Imagem ?? string.Empty,
                Site = novoEventoDto.Site ?? string.Empty,
                Destaques = novoEventoDto.Destaques
            };

            // Adiciona ao banco em memória e salva as alterações
            _context.Eventos.Add(novoEvento);
            await _context.SaveChangesAsync();

            // O Entity Framework gera o Id automaticamente. Devolvemos o Id gerado para o DTO.
            novoEventoDto.Id = novoEvento.Id;

            // Retorna o status 201 (Created) e os dados do objeto criado
            return CreatedAtAction(nameof(GetEventos), new { id = novoEvento.Id }, novoEventoDto);
        }
    }
}