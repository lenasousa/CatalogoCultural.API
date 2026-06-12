using CatalogoCultural.API.Data;
using CatalogoCultural.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoCultural.API.Data
{
    public static class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Eventos.Any())
            {
                return;
            }

            var eventosIniciais = new List<Evento>
            {
                new Evento {
                    Id = 1, Nome = "Virada Cultural Mockada", Tipo = "Festival", Bairro = "Centro", Endereco = "Vários locais do Centro Histórico",
                    Descricao = "Maior evento cultural gratuito da cidade com música e artes.", Zona = "Central", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-06-20", Imagem = "", Site = "https://viradacultural.prefeitura.sp.gov.br",
                    Destaques = new List<string> { "Show principal no Anhangabaú", "Palco de Teatro" }
                },
                new Evento {
                    Id = 2, Nome = "Feira de Inovação e ESG", Tipo = "Exposição", Bairro = "Vila Olímpia", Endereco = "Av. das Nações Unidas, 12551",
                    Descricao = "Exposição de tecnologias verdes e práticas de governança corporativa.", Zona = "Sul", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-07-15", Imagem = "https://picsum.photos/seed/esg/400/200", Site = "https://exemplo.com/inovacao-esg",
                    Destaques = new List<string> { "Palestras gratuitas", "Networking" }
                },
                new Evento {
                    Id = 3, Nome = "Exposição Tarsila", Tipo = "Museu", Bairro = "Luz", Endereco = "Praça da Luz, 2",
                    Descricao = "Retrospectiva completa das obras da fase modernista.", Zona = "Central", Gratuito = false, Valor = "R$ 30,00",
                    Data = "2026-06-25", Imagem = "", Site = "https://pinacoteca.org.br",
                    Destaques = new List<string> { "Quadros inéditos", "Visita guiada" }
                },
                new Evento {
                    Id = 4, Nome = "Festival de Inverno", Tipo = "Festival", Bairro = "Itaquera", Endereco = "Parque do Carmo",
                    Descricao = "Festival de música clássica e jazz ao ar livre nas tardes de domingo.", Zona = "Leste", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-07-10", Imagem = "https://picsum.photos/seed/inverno/400/200", Site = "",
                    Destaques = new List<string> { "Food trucks", "Música ao ar livre" }
                },
                new Evento {
                    Id = 5, Nome = "Sinfonia Sustentável", Tipo = "Show Musical", Bairro = "Luz", Endereco = "Sala São Paulo",
                    Descricao = "Apresentação da OSESP com instrumentos feitos de materiais reciclados.", Zona = "Central", Gratuito = false, Valor = "R$ 50,00",
                    Data = "2026-08-05", Imagem = "https://picsum.photos/seed/sinfonia/400/200", Site = "https://osesp.art.br",
                    Destaques = new List<string> { "Orquestra completa", "Acessibilidade" }
                },
                new Evento {
                    Id = 6, Nome = "Mostra de Cinema de Rua", Tipo = "Cinema", Bairro = "Pinheiros", Endereco = "Largo da Batata",
                    Descricao = "Projeção de filmes independentes ao ar livre.", Zona = "Oeste", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-06-28", Imagem = "", Site = "",
                    Destaques = new List<string> { "Curtas nacionais", "Debate com diretores" }
                },
                new Evento {
                    Id = 7, Nome = "Peça: O Auto da Compadecida", Tipo = "Teatro", Bairro = "Bela Vista", Endereco = "Av. Brigadeiro Luís Antônio",
                    Descricao = "Montagem moderna do clássico de Ariano Suassuna.", Zona = "Central", Gratuito = false, Valor = "R$ 80,00",
                    Data = "2026-07-22", Imagem = "", Site = "https://exemplo.com/teatro",
                    Destaques = new List<string> { "Elenco premiado", "Cenário interativo" }
                },
                new Evento {
                    Id = 8, Nome = "Bienal do Livro", Tipo = "Festival", Bairro = "Santana", Endereco = "Expo Center Norte",
                    Descricao = "Encontro de grandes autores, editoras e painéis de discussão.", Zona = "Norte", Gratuito = false, Valor = "R$ 35,00",
                    Data = "2026-09-06", Imagem = "https://picsum.photos/seed/livro/400/200", Site = "https://bienaldolivrosp.com.br",
                    Destaques = new List<string> { "Sessões de autógrafos", "Pavilhão infantil" }
                },
                new Evento {
                    Id = 9, Nome = "Jazz no Parque", Tipo = "Show Musical", Bairro = "Ibirapuera", Endereco = "Parque Ibirapuera - Portão 10",
                    Descricao = "Apresentações de Jazz e Blues no fim de tarde.", Zona = "Sul", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-08-15", Imagem = "", Site = "",
                    Destaques = new List<string> { "Gramado liberado", "Pet-friendly" }
                },
                new Evento {
                    Id = 10, Nome = "Imersão Van Gogh", Tipo = "Exposição", Bairro = "Morumbi", Endereco = "Shopping Morumbi",
                    Descricao = "Experiência audiovisual imersiva nas obras do pintor holandês.", Zona = "Sul", Gratuito = false, Valor = "R$ 90,00",
                    Data = "2026-07-05", Imagem = "https://picsum.photos/seed/arte/400/200", Site = "https://vangoghexpo.com.br",
                    Destaques = new List<string> { "Salas em 360º", "Realidade Virtual" }
                },
                new Evento {
                    Id = 11, Nome = "Cultura Maker & Tech", Tipo = "Outro", Bairro = "Pompeia", Endereco = "Sesc Pompeia",
                    Descricao = "Oficinas de robótica, impressão 3D e programação criativa.", Zona = "Oeste", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-08-20", Imagem = "", Site = "https://sescsp.org.br/pompeia",
                    Destaques = new List<string> { "Laboratório aberto", "Monitoria inclusiva" }
                },
                new Evento {
                    Id = 12, Nome = "Festival das Nações", Tipo = "Festival", Bairro = "Mooca", Endereco = "Clube Atlético Juventus",
                    Descricao = "Celebração gastronômica e cultural de diversas nacionalidades.", Zona = "Leste", Gratuito = false, Valor = "R$ 20,00",
                    Data = "2026-09-12", Imagem = "https://picsum.photos/seed/comida/400/200", Site = "",
                    Destaques = new List<string> { "Culinária típica", "Danças folclóricas" }
                },
                new Evento {
                    Id = 13, Nome = "Sábado no Museu", Tipo = "Museu", Bairro = "Ipiranga", Endereco = "Museu do Ipiranga",
                    Descricao = "Acesso gratuito aos acervos de história do Brasil.", Zona = "Sul", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-10-03", Imagem = "", Site = "https://museudoipiranga.org.br",
                    Destaques = new List<string> { "Jardins franceses", "Acervo restaurado" }
                },
                new Evento {
                    Id = 14, Nome = "Noite de Stand-up", Tipo = "Show Musical", Bairro = "Augusta", Endereco = "Rua Augusta, 1000",
                    Descricao = "Os melhores comediantes da atualidade testando novas piadas.", Zona = "Central", Gratuito = false, Valor = "R$ 45,00",
                    Data = "2026-07-18", Imagem = "", Site = "",
                    Destaques = new List<string> { "Open mic", "Convidados surpresa" }
                },
                new Evento {
                    Id = 15, Nome = "Semana de Arte Urbana", Tipo = "Exposição", Bairro = "Vila Madalena", Endereco = "Beco do Batman",
                    Descricao = "Pintura de novos murais ao vivo com artistas locais e internacionais.", Zona = "Oeste", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-10-15", Imagem = "https://picsum.photos/seed/grafite/400/200", Site = "",
                    Destaques = new List<string> { "Grafite ao vivo", "Venda de prints" }
                },
                new Evento {
                    Id = 16, Nome = "Mostra Japão", Tipo = "Festival", Bairro = "Liberdade", Endereco = "Praça da Liberdade",
                    Descricao = "Celebração da cultura japonesa com taiko, cosplay e comida.", Zona = "Central", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-07-25", Imagem = "", Site = "https://exemplo.com/mostrajapao",
                    Destaques = new List<string> { "Apresentação de Taiko", "Concurso Cosplay" }
                },
                new Evento {
                    Id = 17, Nome = "Orquestra no Parque", Tipo = "Show Musical", Bairro = "Alto de Pinheiros", Endereco = "Parque Villa-Lobos",
                    Descricao = "Concerto ao pôr do sol tocando trilhas sonoras de filmes.", Zona = "Oeste", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-11-01", Imagem = "https://picsum.photos/seed/musica/400/200", Site = "",
                    Destaques = new List<string> { "Trilhas de cinema", "Área para piquenique" }
                },
                new Evento {
                    Id = 18, Nome = "Teatro: O Fantasma da Ópera", Tipo = "Teatro", Bairro = "Santo Amaro", Endereco = "Teatro Alfa",
                    Descricao = "O musical mais famoso do mundo em nova temporada.", Zona = "Sul", Gratuito = false, Valor = "R$ 150,00",
                    Data = "2026-08-30", Imagem = "", Site = "https://teatroalfa.com.br",
                    Destaques = new List<string> { "Super produção", "Orquestra ao vivo" }
                },
                new Evento {
                    Id = 19, Nome = "Exposição: Oceano Sustentável", Tipo = "Exposição", Bairro = "Jardim Europa", Endereco = "Museu da Imagem e do Som (MIS)",
                    Descricao = "Fotografias interativas sobre a preservação da vida marinha.", Zona = "Oeste", Gratuito = false, Valor = "R$ 25,00",
                    Data = "2026-09-22", Imagem = "https://picsum.photos/seed/oceano/400/200", Site = "https://mis-sp.org.br",
                    Destaques = new List<string> { "Projeções", "Realidade aumentada" }
                },
                new Evento {
                    Id = 20, Nome = "Festival Nordestino", Tipo = "Festival", Bairro = "Brás", Endereco = "Centro de Tradições Nordestinas",
                    Descricao = "Muito forró, baião de dois e literatura de cordel.", Zona = "Central", Gratuito = false, Valor = "R$ 15,00",
                    Data = "2026-11-15", Imagem = "", Site = "https://ctn.org.br",
                    Destaques = new List<string> { "Forró ao vivo", "Gastronomia" }
                },
                new Evento {
                    Id = 21, Nome = "Cinema Inclusivo", Tipo = "Cinema", Bairro = "Penha", Endereco = "Centro Cultural da Penha",
                    Descricao = "Sessões de cinema adaptadas para pessoas com espectro autista.", Zona = "Leste", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-06-22", Imagem = "https://picsum.photos/seed/cinema/400/200", Site = "",
                    Destaques = new List<string> { "Luzes amenas", "Som reduzido" }
                },
                new Evento {
                    Id = 22, Nome = "Feira Orgânica e Cultural", Tipo = "Outro", Bairro = "Tatuapé", Endereco = "Parque Piqueri",
                    Descricao = "Feira de produtores locais acompanhada de música acústica.", Zona = "Leste", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-08-08", Imagem = "", Site = "",
                    Destaques = new List<string> { "Hortifruti sem agrotóxicos", "Música ambiente" }
                },
                new Evento {
                    Id = 23, Nome = "Museu da Língua Viva", Tipo = "Museu", Bairro = "Luz", Endereco = "Museu da Língua Portuguesa",
                    Descricao = "Exposição sobre as variações linguísticas do Brasil.", Zona = "Central", Gratuito = false, Valor = "R$ 20,00",
                    Data = "2026-10-20", Imagem = "https://picsum.photos/seed/museu/400/200", Site = "https://museudalinguaportuguesa.org.br",
                    Destaques = new List<string> { "Árvore de palavras", "Jogos interativos" }
                },
                new Evento {
                    Id = 24, Nome = "Roda de Samba", Tipo = "Show Musical", Bairro = "Vila Madalena", Endereco = "Rua Aspicuelta",
                    Descricao = "Samba de raiz e pagode em um ambiente descontraído.", Zona = "Oeste", Gratuito = false, Valor = "R$ 30,00",
                    Data = "2026-12-05", Imagem = "", Site = "",
                    Destaques = new List<string> { "Música ao vivo", "Caipirinhas" }
                },
                new Evento {
                    Id = 25, Nome = "Teatro Infantil: A Floresta", Tipo = "Teatro", Bairro = "Santana", Endereco = "Sesc Santana",
                    Descricao = "Peça educativa sobre a preservação da fauna brasileira.", Zona = "Norte", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-10-12", Imagem = "https://picsum.photos/seed/natureza/400/200", Site = "https://sescsp.org.br/santana",
                    Destaques = new List<string> { "Cenário de material reciclado", "Livre para todas as idades" }
                },
                new Evento {
                    Id = 26, Nome = "Cine Clube Noturno", Tipo = "Cinema", Bairro = "Jardim Paulista", Endereco = "Reserva Cultural",
                    Descricao = "Sessão dupla de clássicos do terror dos anos 80.", Zona = "Central", Gratuito = false, Valor = "R$ 40,00",
                    Data = "2026-10-31", Imagem = "", Site = "",
                    Destaques = new List<string> { "Sessão dupla", "Pôsteres de brinde" }
                },
                new Evento {
                    Id = 27, Nome = "Exposição Afro-Brasil", Tipo = "Exposição", Bairro = "Ibirapuera", Endereco = "Museu Afro Brasil",
                    Descricao = "História, cultura e contribuições africanas no Brasil.", Zona = "Sul", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-11-20", Imagem = "https://picsum.photos/seed/cultura/400/200", Site = "https://museuafrobrasil.org.br",
                    Destaques = new List<string> { "Esculturas", "Fatos históricos" }
                },
                new Evento {
                    Id = 28, Nome = "Rock in Park", Tipo = "Festival", Bairro = "Santana", Endereco = "Campo de Marte",
                    Descricao = "Bandas covers de rock clássico animando a zona norte.", Zona = "Norte", Gratuito = false, Valor = "R$ 60,00",
                    Data = "2026-09-07", Imagem = "", Site = "",
                    Destaques = new List<string> { "Dois palcos", "Praça de alimentação" }
                },
                new Evento {
                    Id = 29, Nome = "Bazar de Artesanato", Tipo = "Outro", Bairro = "Santo Amaro", Endereco = "Largo Treze",
                    Descricao = "Artesãos locais expondo e vendendo suas peças autorais.", Zona = "Sul", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-12-10", Imagem = "https://picsum.photos/seed/artesanato/400/200", Site = "",
                    Destaques = new List<string> { "Economia circular", "Apoio local" }
                },
                new Evento {
                    Id = 30, Nome = "Festa de Ano Novo", Tipo = "Festival", Bairro = "Paulista", Endereco = "Avenida Paulista",
                    Descricao = "A tradicional virada de ano com grandes shows nacionais.", Zona = "Central", Gratuito = true, Valor = "R$ 00,00",
                    Data = "2026-12-31", Imagem = "", Site = "https://exemplo.com/anonovosp",
                    Destaques = new List<string> { "Contagem regressiva", "Shows diversificados" }
                }
            };

            context.Eventos.AddRange(eventosIniciais);
            context.SaveChanges();
        }
    }
}