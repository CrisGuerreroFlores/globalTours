using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        /*
        private readonly ILugarRepository _repo;
        public LugaresController(ILugarRepository repo)
        {
            _repo = repo;
            
        }*/
        private readonly IRepository<Lugar> _lugarRepo;
        private readonly IRepository<Pais> _paisRepo;
        private readonly IRepository<Categoria> _categRepo;
        private readonly IMapper _mapper;

        public LugaresController(IRepository<Lugar> lugarRepo,
                                 IRepository<Pais> paisRepo,
                                 IRepository<Categoria> categRepo, IMapper mapper)
        {
            _mapper = mapper;
            _categRepo = categRepo;
            _paisRepo = paisRepo;
            _lugarRepo = lugarRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LugarDto>>> GetLugares()
        {
            var specification = new LugaresWithPaisCategoriaSpecification();
            var lugares = await _lugarRepo.GetAllsSpecification(specification);

            return Ok(_mapper.Map<IReadOnlyList<Lugar>, IReadOnlyList<LugarDto>>(lugares));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LugarDto>> GetLugar(int id)
        {
            var specification = new LugaresWithPaisCategoriaSpecification(id);
            var lugar = await _lugarRepo.GetSpecification(specification);

            return _mapper.Map<Lugar, LugarDto>(lugar);
        }

        [HttpGet("paises")]
        public async Task<ActionResult<List<Pais>>> GetPaises()
        {
            return Ok(await _paisRepo.GetAllsAsync());
        }

        [HttpGet("categorias")]
        public async Task<ActionResult<List<Pais>>> GetCategorias()
        {
            return Ok(await _categRepo.GetAllsAsync());
        }
    }
}