# Desafio Técnico – Target

Solução em **C#** para o desafio técnico da Target. Um único programa de console, com um menu que dá acesso aos três desafios propostos.

A solução foi mantida propositalmente simples, atendendo apenas ao que o enunciado pede.

## Desafios

| # | Desafio | Resumo |
|---|---------|--------|
| 1 | Cálculo de comissão | Lê as vendas (JSON) e calcula a comissão total de cada vendedor |
| 2 | Movimentação de estoque | Lança entradas e saídas de produtos e informa o estoque final |
| 3 | Cálculo de juros | Calcula os juros de um valor vencido, com base na data de vencimento |

### 1. Cálculo de comissão

Lê o JSON de vendas e, para cada venda, aplica a regra:

| Valor da venda | Comissão |
|----------------|----------|
| Abaixo de R$ 100,00 | Sem comissão |
| De R$ 100,00 até abaixo de R$ 500,00 | 1% |
| A partir de R$ 500,00 | 5% |

O programa soma as comissões por vendedor e exibe o total de cada um.

**Resultado esperado com os dados do desafio:**

| Vendedor | Comissão |
|----------|----------|
| João Silva | R$ 495,68 |
| Maria Souza | R$ 465,95 |
| Carlos Oliveira | R$ 379,37 |
| Ana Lima | R$ 404,98 |

### 2. Movimentação de estoque

Carrega os produtos do JSON de estoque e permite lançar movimentações de **entrada** ou **saída**. Cada movimentação possui:

- um **identificador único**;
- uma **descrição** do tipo da movimentação (ex.: "Entrada", "Saída");
- o produto, a quantidade e a data/hora.

Ao final de cada lançamento, o programa mostra a **quantidade final em estoque** do produto movimentado.

A saída é recusada se a quantidade pedida for maior que o estoque disponível.

### 3. Cálculo de juros

Recebe um **valor** e uma **data de vencimento**, e calcula os juros até a data de hoje, usando a taxa de **2,5% ao dia**:

```
juros = valor × 0,025 × dias_em_atraso
```

Se a data de vencimento ainda não passou, os juros são R$ 0,00.

> Considerei juros simples (sem capitalização). O enunciado fala em "multa de 2,5% ao dia" e pede o "valor dos juros"; tratei como uma taxa diária aplicada ao valor original.

## Como executar

**Pré-requisito:** [.NET SDK](https://dotnet.microsoft.com/download) instalado.

```bash
git clone [https://github.com/anderwill80/CSharp)]
cd <csharp>
dotnet run
```

Ao iniciar, aparece o menu:

```
=======================================
            TARGET SISTEMAS
     SELECIONE O DESAFIO DESEJADO     
=======================================
1 - Desafio 1 - COMISSAO POR VENDEDOR
2 - Desafio 2 - MOVIMENTACAO DE ESTOQUE
3 - Desafio 3 - CALCULO DE JUROS 2.5%
0 - Sair
=======================================
Digite a sua opção:
```
Escolha a opção digitando o número correspondente e pressione Enter.

## Tecnologias

- C#
- .NET
- Aplicação de console

## Autor

**Anderson William da Silva**
**Desenvolvedor C# | SQL Server | ERP**
