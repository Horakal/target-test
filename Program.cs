

using Newtonsoft.Json;
using target_test;

/**
 * 1)	Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0; 
 *  Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; }
 *   Imprimir(SOMA); 
 *  Ao final do processamento, qual será o valor da variável SOMA? 
 */
int indice = 13 ,soma = 0, k =0;

while (k < indice)
{
    k = k + 1;
    soma = soma + k;
}
Console.WriteLine(soma);

// iterative fibbonaci

/**
 * 2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o 
 * próximo valor sempre será a soma dos 2 valores anteriores 
 * (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), 
 * escreva um programa na linguagem que desejar onde, 
 * informado um número, ele calcule a sequência de Fibonacci 
 * e retorne uma mensagem avisando se o número informado pertence ou não a sequência. 
 */
static bool isPerfectSquare(int x)
{
    int s = (int)Math.Sqrt(x);
    return (s * s == x);
}
/**
 * IdentificationBinet's formula provides a proof that a positive integer x is a 
 * Fibonacci number if and only if at least one of 5 x 2 + 4 {\displaystyle 5x^{2}+4} or 5 x 2 − 4 {\displaystyle 5x^{2}-4} 
 * is a perfect square.[29] This is because Binet's formula,
 * src=https://en.wikipedia.org/wiki/Fibonacci_sequence#Recognizing_Fibonacci_numbers
 */
static bool isInFibonacci(int n)
{
    return isPerfectSquare(5 * n * n + 4) ||
        isPerfectSquare(5 * n * n - 4);
}
var result = isInFibonacci(4);
Console.WriteLine($"O numero faz parte da sequencia de fibo ? {result} ");


/**
 * 3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne: 
 *  • O menor valor de faturamento ocorrido em um dia do mês; 
 *   • O maior valor de faturamento ocorrido em um dia do mês; 
 *   • Número de dias no mês em que o valor de faturamento diário foi superior à média mensal. 
 *   IMPORTANTE: 
 *   a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal; 
 *   b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;
 */
LoadJson();

void LoadJson()
{
    string docPath = System.Environment.CurrentDirectory;
    using StreamReader r = new(Path.Combine(docPath, "dados.json"));
    string json = r.ReadToEnd();
    List<JsonItem>? items = JsonConvert.DeserializeObject<List<JsonItem>>(json);

    if (items == null)
    {
        Console.WriteLine("Erro: O arquivo JSON não contém dados válidos.");
        return;
    }
    List<JsonItem> noZeroValue  = [.. items.Where(x => x.valor > 0)];
    float minDayValue = noZeroValue.Min(x => x.valor);
    float maxDayValue = noZeroValue.Max(x => x.valor);
    float average = noZeroValue.Average(x => x.valor);
    int daysAboveAverage = noZeroValue.Count(x => x.valor > average);
    Console.WriteLine($"Menor valor: {minDayValue}");
    Console.WriteLine($"Maior valor: {maxDayValue}");
    Console.WriteLine($"Média: {average}");
    Console.WriteLine($"Dias acima da média: {daysAboveAverage}");
}




/**
 * 4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado: 
    •	SP – R$67.836,43 
    •	RJ – R$36.678,66 
    •	MG – R$29.229,88 
    •	ES – R$27.165,48 
    •	Outros – R$19.849,53 
    Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.  
 */
List<StatesMontly> statesMonthlies =
[
    new ("SP", 67836.43),
    new("RJ", 36678.66),
    new ("MG", 29229.88),
    new ("ES", 27165.48),
    new ("Outros", 19849.53)
];

var total = statesMonthlies.Sum(x => x.Value);
var percent = statesMonthlies.Select(x => new
{
    x.State,
    Percent = Math.Round((x.Value / total) * 100, 4)
}).ToList();

foreach (var item in percent)
{
    Console.WriteLine($"Estado: {item.State} - Percentual no faturamento mensal: {item.Percent}%");
}


/**
 * 5) Escreva um programa que inverta os caracteres de um string. 
 * IMPORTANTE:
 * a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
 * b) Evite usar funções prontas, como, por exemplo, reverse; 
 */

Console.Write("Enter a String : ");
string originalString = Console.ReadLine() ?? string.Empty;
string reverseString = string.Empty;
foreach (char c in originalString)
{
    reverseString = c + reverseString;
}

Console.WriteLine($"Reversed string: {reverseString}");
