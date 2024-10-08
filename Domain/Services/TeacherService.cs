using AutoMapper;
using Contracts;
using Domain.Entities.Users;
using Domain.Repository;
using Services.Abstractions;


namespace Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<TeacherDto> CreateAsync(TeacherDtoForCreate teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            await _teacherRepository.AddAsync(teacher);
            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task<List<TeacherDto>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return _mapper.Map<List<TeacherDto>>(teachers);
        }

        public async Task<TeacherDto> GetByIdAsync(Guid id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                throw new KeyNotFoundException("Teacher not found");
            }

            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task UpdateAsync(Guid teacherId, TeacherDtoForUpdate teacherDto)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId);

            if (teacher == null)
            {
                throw new KeyNotFoundException("Teacher not found");
            }

            _mapper.Map(teacherDto, teacher); // Преобразование данных DTO в сущность
            await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task DeleteAsync(Guid teacherId)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId);

            if (teacher == null)
            {
                throw new KeyNotFoundException("Teacher not found");
            }

            await _teacherRepository.DeleteAsync(teacher);
        }

        public async Task<TeacherDto> AutoAssignTeacherToClientAsync(Guid clientId, DateTime lessonTime)
        {
            // Логика поиска подходящего преподавателя
            throw new NotImplementedException();
        }
    }

}
