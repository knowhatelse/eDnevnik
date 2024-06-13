using AutoMapper;
using eDnevnik___backend.Data;
using eDnevnik___backend.DTOs.NoteDto;
using eDnevnik___backend.Entities;
using eDnevnik___backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eDnevnik___backend.Services;

public class NoteService(eDnevnikDbContext context, IMapper mapper)
    : BaseCRUDService<Note, GetNoteDto, CreateNoteDto, UpdateNoteDto>(context, mapper), INoteService
{
    private readonly eDnevnikDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public List<GetNoteDto>? GetNotesByStudent(int studentId)
    {
        var studentNotes = _context.Notes.Include(n => n.Teacher).Where(n => n.StudentId == studentId).ToList();
        return studentNotes.Count == 0 ? null : _mapper.Map<List<GetNoteDto>>(studentNotes);
    }

    public override List<GetNoteDto>? GetAll(int schoolId)
    {
        var records = _context.Notes.ToList();
        return records.Count == 0 ? null : _mapper.Map<List<GetNoteDto>>(records);
    }
}