using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class Motoboy{
    public string nomeDoMotoboy { get; set; } 
    public string telefone { get; set; }
    public string status = "Disponível na Base"; // vindo padrao do atributo, sem precisar passar argumento no construtor 

    public Motoboy() { }

    public Motoboy(string nomeDoMotoboy, string telefone)
    {
        this.nomeDoMotoboy = nomeDoMotoboy;
        this.telefone = telefone;
    }

    public void ExibirCadastroDoMotoboy()
    {
        Console.WriteLine($"Motoboy: {nomeDoMotoboy} | Telefone: {telefone}");
    }

    public void AlterarStatus(string novoStatus)
    {
        status = novoStatus;
    }
}
