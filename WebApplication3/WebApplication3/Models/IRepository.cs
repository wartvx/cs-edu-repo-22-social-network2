//-
using System;
using System.Collections.Generic;


namespace WebApplication3.Models;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? Get(int id);
    void Create(T item);
    void Update(T item);
    void Delete(T item);
}
