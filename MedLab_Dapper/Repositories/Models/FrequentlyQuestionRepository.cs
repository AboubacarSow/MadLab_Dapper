using Dapper;
using MedLab_Dapper.Dtos.FrequentlyQuestionDtos;
using MedLab_Dapper.Repositories.Context;
using MedLab_Dapper.Repositories.Contracts;

namespace MedLab_Dapper.Repositories.Models;

public class FrequentlyQuestionRepository : IFrequentlyQuestionRepository
{
    private readonly DapperDbContext _context;  
    public FrequentlyQuestionRepository(DapperDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateFrequentlyQuestion question)
    {
        var query = @"
            INSERT INTO FrequentlyQuestions (Question, Answer)
            VALUES (@Question, @Answer)";
        var parameters = new DynamicParameters();
        parameters.Add("Question", question.Question);
        parameters.Add("Answer", question.Answer);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }

    public async Task DeleteAsync(int id)
    {
        var query = @"
            DELETE FROM FrequentlyQuestions
            WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<ResultFrequentlyQuestion>> GetAllAsync()
    {
        var query = @"
            SELECT * FROM FrequentlyQuestions";
        return await _context.CreateConnection().QueryAsync<ResultFrequentlyQuestion>(query);
    }

    public async Task<UpdateFrequentlyQuestion> GetByIdAsync(int id)
    {
        var query = @"
            SELECT * FROM FrequentlyQuestions
            WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id);
        return await _context.CreateConnection().QueryFirstOrDefaultAsync<UpdateFrequentlyQuestion>(query, parameters);
    }

    public async Task UpdateAsync(UpdateFrequentlyQuestion question)
    {
        var query = @"
            UPDATE FrequentlyQuestions
            SET Question = @Question, Answer = @Answer
            WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", question.Id);
        parameters.Add("Question", question.Question);
        parameters.Add("Answer", question.Answer);
        await _context.CreateConnection().ExecuteAsync(query, parameters);
    }
}
