using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Infrastructure.Reposistories;
using eVoucher.Service.Dtos;
using eVoucher.Domain.Models;

namespace eVoucher.Service.Serivces
{
    public class GameService : IGameService
    {
        private readonly IDomainRepository _domainRepository;
        private readonly IMapper _mapper;

        public GameService(IDomainRepository domainRepository, IMapper mapper)
        {
            _domainRepository = domainRepository;
            _mapper = mapper;
        }

        public async Task<GameDto> GetGameById(Guid id)
        {
            var game = _domainRepository.GetOne<Game>(c => c.Id == id);
            return _mapper.Map<Game, GameDto>(game);
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            try
            {
                var game = _domainRepository.GetOne<Game>(u => u.Id == id);

                if (game is not null) // delete 
                {
                    _domainRepository.Remove(game, true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateGame(GameDto gameDto)
        {
            try
            {
                if (gameDto != null)
                {
                    if (gameDto.ID != Guid.Empty) // update
                    {
                        var game = _mapper.Map<GameDto, Game>(gameDto);
                        game.CreatedBy = _domainRepository.GetOne<User>(u => u.Id == gameDto.CreatedBy);
                        game.ModifiedBy = _domainRepository.GetOne<User>(u => u.Id == gameDto.ModifiedBy);
                        _domainRepository.Update(game, true);
                        return true;
                    }// add
                    else
                    {
                        var game = _mapper.Map<Game>(gameDto);
                        game.CreatedBy = _domainRepository.GetOne<User>(u => u.Id == gameDto.CreatedBy);
                        game.ModifiedBy = _domainRepository.GetOne<User>(u => u.Id == gameDto.ModifiedBy);
                        _domainRepository.Add(game, true);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
