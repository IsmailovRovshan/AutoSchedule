using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Entities.Users;
using Domain.Repository;
using Services.Abstractions;

namespace Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public LessonService(
            ILessonRepository lessonRepository,
            ITeacherRepository teacherRepository,
            IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<LessonDto> CreateAsync(LessonDtoForCreate lessonDto)
        {
            if (lessonDto.LessonDate.Minute != 0  || lessonDto.LessonDate.Second != 0)
            {
                throw new Exception("Неправильный формат времени");
            }

            var teacher = await _teacherRepository.GetByIdAsync(lessonDto.TeacherId);

            if (teacher == null)
            {
                throw new Exception("Преподавателя не существует");
            }
            if (lessonDto.LessonDate < teacher.StartWork || lessonDto.LessonDate > teacher.EndWork)
            {
                throw new Exception("Преподаватель не работает в это время");
            }

            if (!await _lessonRepository.IsTeacherFree(teacher, lessonDto.LessonDate))
            {
                throw new Exception("Преподаватель занят");
            }

            var lesson = _mapper.Map<Lesson>(lessonDto);
            await _lessonRepository.AddAsync(lesson);
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task<LessonDto> CreateAuto(LessonDtoForAutoCreate lessonDto)
        {
            if (lessonDto.LessonDate.Minute != 0 || lessonDto.LessonDate.Second != 0)
            {
                throw new Exception("Неправильный формат времени");
            }

            var teahcers = await _teacherRepository.TeachersCanWorkAtThisTime(lessonDto.LessonDate);
            Teacher? teacher = null;

            foreach (var item in teahcers)
            {
                if (await _lessonRepository.IsTeacherFree(item, lessonDto.LessonDate))
                {
                    teacher = item;
                    break;
                }

            }
            if (teacher == null)
                throw new Exception("Нет свободных преподавателей на это время");


            var lesson = _mapper.Map<Lesson>(lessonDto);
            lesson.TeacherId = teacher.Id;

            await _lessonRepository.AddAsync(lesson);
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task DeleteAsync(Guid TeacherId, Guid ClientId)
        {
            var lesson = await _lessonRepository.GetByIdAsync( TeacherId, ClientId);
            if (lesson == null)
            {
                throw new KeyNotFoundException("Урок не найден.");
            }
            await _lessonRepository.DeleteAsync(lesson);
        }

        public async Task<List<LessonDto>> GetAllAsync()
        {
            var lessons = await _lessonRepository.GetAllAsync();
            return _mapper.Map<List<LessonDto>>(lessons);
        }

        public async Task<LessonDto> GetByIdAsync(Guid TeacherId, Guid ClientId)
        {
            var lesson = await _lessonRepository.GetByIdAsync(TeacherId, ClientId);
            if (lesson == null)
            {
                throw new KeyNotFoundException("Урок не найден.");
            }
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task UpdateAsync(Guid TeacherId, Guid ClientId, LessonDtoForUpdate lessonDto)
        {
            var lesson = await _lessonRepository.GetByIdAsync(TeacherId, ClientId);

            if (lesson == null)
            {
                throw new KeyNotFoundException("Урок не найден.");
            }

            _mapper.Map(lessonDto, lesson);

            await _lessonRepository.UpdateAsync(lesson);
        }

        public async Task<List<LessonDto>> GetLessonsByDateAsync(Guid teacherId, DateTime date)
        {
            var lessons = await _lessonRepository.GetLessonsByDateAsync(teacherId, date);
            return _mapper.Map<List<LessonDto>>(lessons);
        }
    }
}
