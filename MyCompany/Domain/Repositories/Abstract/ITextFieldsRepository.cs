using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextField();   //выборка всех текстовых полей
        TextField GetTextFieldById(Guid id);    //выборка текстового поля по id
        TextField GetTextFieldByCodeWord(string codeWord);  //выборка текстового поля по кодовому слову
        void SaveTextField(TextField textField);    //сохранение текстового поля
        void DeleteTextField(Guid id);  //удаление текстового поля
    }
}
