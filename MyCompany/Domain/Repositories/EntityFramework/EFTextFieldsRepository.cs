using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;

        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField { Id = id });
            context.SaveChanges();
        }

        public IQueryable<TextField> GetTextField() 
            => context.TextFields;


        public TextField GetTextFieldByCodeWord(string codeWord)
            => context.TextFields.FirstOrDefault(c => c.CodeWord == codeWord);


        public TextField GetTextFieldById(Guid id)
            => context.TextFields.FirstOrDefault(c => c.Id == id);


        //!!!!!ПОСМОТРЕТЬ
        public void SaveTextField(TextField textField)
        {
            if (textField.Id == default)
                context.Entry(textField).State = EntityState.Added; //добавляем в базу данных
            else
                context.Entry(textField).State = EntityState.Modified;  //изменяем существующий элемент
            context.SaveChanges();
        }
    }
}
