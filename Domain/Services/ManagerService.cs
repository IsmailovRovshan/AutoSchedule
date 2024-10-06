using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Repository;
using Services.Abstractions;

namespace Services
{
    public class ManagerService : IManagerService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ILessonRepository _lessonRepository;

        private readonly IMapper _mapper;

        public ManagerService
            (IClientRepository clientRepository, 
            ITeacherRepository teacherRepository, 
            ILessonRepository lessonRepository,
            IMapper mapper)
        {
            _clientRepository = clientRepository;
            _teacherRepository = teacherRepository;
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }
        public async Task<ClientDTO> CreateClientAsync(ClientDTO clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.AddAsync(client);
            return _mapper.Map<ClientDTO>(client);
        }

        public Task AutoSearchTeacherForClient(Guid clientId, DateTime lessonDate)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteClientAsync(Guid clientId)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
            {
                throw new KeyNotFoundException("Client not found.");
            }

            await _clientRepository.DeleteAsync(client);
        }

        public Task UpdateClientAsync(ClientDTO clientDto)
        {
            throw new NotImplementedException();
        }
    }
}
