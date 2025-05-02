using System.Globalization;

System.Console.WriteLine("Digite o caminho completo do arquivo:");
string arquivoOrigem = Console.ReadLine();

try {
    string [] linhas = File.ReadAllLines(arquivoOrigem);

    string pastaFonte = Path.GetDirectoryName(arquivoOrigem);
    string pastaDestino = pastaFonte + @"\saida";
    string arquivoDestino = pastaDestino + @"\resumo.csv";
    
    Directory.CreateDirectory(pastaDestino); //pasta saída

    using (StreamWriter sw = File.AppendText(arquivoDestino)) {
        foreach (string item in linhas)
        {
            string [] campo = item.Split(',');
            string nome = campo[0];
            double preco = double.Parse(campo[1], CultureInfo.InvariantCulture);
            int quantidade = int.Parse(campo[2]);

            Produto produto = new Produto(nome,preco,quantidade);
            sw.WriteLine(produto.Nome + "," + produto.Soma().ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
catch (IOException e) {
    System.Console.WriteLine("Ocorreu um erro");
    System.Console.WriteLine(e.Message);
}