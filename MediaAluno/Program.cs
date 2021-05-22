using System;

namespace opcao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno [5];
            var indiceAluno =0;   
            string OpcaoUsuario = Menu();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno");
                        Aluno aluno = new Aluno (); 
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException ("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;  

                        break;
                    case "2":
                            foreach (var a in alunos)
                            {
                                if (!string.IsNullOrEmpty(a.Nome))
                                {
                                    Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}"); 
                                }
                            }

                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                    notaTotal = notaTotal + alunos[i].Nota;
                                    nrAlunos++; 
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceitoenum conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceitoenum.E;
                        }
                        else if (mediaGeral <4)
                        {
                            conceitoGeral = Conceitoenum.D;
                        }
                        else if (mediaGeral <6)
                        {
                            conceitoGeral = Conceitoenum.C;
                        }
                        else if (mediaGeral <8)
                        {
                            conceitoGeral = Conceitoenum.B;
                        }
                        else 
                        {
                            conceitoGeral = Conceitoenum.A;
                        }
                        Console.WriteLine($"Média Geral: {mediaGeral} - CONCEITO: {conceitoGeral}");

                         break;
                    default:
                        throw new ArgumentOutOfRangeException();

                } 

                OpcaoUsuario = Menu();
            }
        }    
            private static string Menu()
            {   
                Console.WriteLine();  
                Console.WriteLine("Informe a opção desejada");
                Console.WriteLine("1 - Inserir novo aluno");
                Console.WriteLine("2 - Listar alunos");
                Console.WriteLine("3 - Calcular média geral");
                Console.WriteLine ("X - Sair");
                Console.WriteLine();

                string OpcaoUsuario = Console.ReadLine();
                Console.WriteLine();
                return OpcaoUsuario;

            }

    }
}
