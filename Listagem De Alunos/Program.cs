using Listagem_De_Alunos;

string opcaoSelecionada = obterOpcaoUsuario();
Aluno[] alunos = new Aluno[5];
var indiceAluno = 0;


while (opcaoSelecionada.ToUpper() != "X")
{
    switch (opcaoSelecionada)
    {
        case "1":
            Console.WriteLine("Informe o nome do aluno:");
            Aluno aluno = new Aluno();
            aluno.Nome = Console.ReadLine();
            Console.WriteLine("Informe a nota do aluno:");
            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
            {
                aluno.Nota = nota;
            }
            else
            {
                throw new ArgumentException("O valor informado não é decimal");
            }
            alunos[indiceAluno] = aluno;
            indiceAluno++;

            break;
        case "2":
            foreach (var a in alunos)
            {
                if (!string.IsNullOrEmpty(a.Nome))
                {
                    Console.WriteLine($"Aluno: {a.Nome}, Nota: {a.Nota}\n");
                }

            }
            break;
        case "3":
            decimal notaTotal = 0;
            var numeroAluno = 0;

            for (int i = 0; i < alunos.Length; i++)
            {
                if (!string.IsNullOrEmpty(alunos[i].Nome))
                {
                    notaTotal = notaTotal + alunos[i].Nota;
                    numeroAluno++;
                }
            }
            var mediaTotal = notaTotal / numeroAluno;

            Conceito conceitoGeral;
            if( mediaTotal < 2) 
            {
                conceitoGeral = Conceito.E;
            }else if( mediaTotal < 4)
            {
                conceitoGeral = Conceito.D;
            }
            else if (mediaTotal < 6)
            {
                conceitoGeral = Conceito.C;
            }
            else if (mediaTotal < 8)
            {
                conceitoGeral = Conceito.B;

            }
            else
            {
                conceitoGeral = Conceito.A;
            }
            Console.WriteLine($"Média geral: {mediaTotal} - Conceito: {conceitoGeral}\n");
            break;
        case "x":
            break;
        default: throw new ArgumentOutOfRangeException();
    }
    opcaoSelecionada = obterOpcaoUsuario();
}
static string obterOpcaoUsuario()
{
    Console.WriteLine("Informe a opção desejada:");
    Console.WriteLine("1 - Inserir novo aluno");
    Console.WriteLine("2 - Listar alunos");
    Console.WriteLine("3 - Calcular média geral");
    Console.WriteLine("x - sair\n");

    string opcaoSelecionada = Console.ReadLine();
    
    return opcaoSelecionada;
}