**Instruções:**
- Mais que avaliar, o objetivo deste momento é permitir o aprendizado de maneira concentrada. Você pode utilizar consultas à Internet para tirar dúvidas. Mas não deve copiar trechos de código da Internet ou dos colegas. Identificação de plágios tornarão o trabalho do aluno anulado e sua nota será zerada.
- Faça comentários significativos em seu código, para mostrar que você sabe o que está fazendo. Esses comentários serão observados no momento da correção.
- Este trabalho deverá ser executado em duplas na sala de aula. 
- Data de entrega: 20/04/2022


**Implementação de um simulador gravitacional**
Implementar simulador gravitacional 2D, que leia as informações dos corpos em um arquivo texto formatado, faça os cálculos necessários e grave os resultados em outro arquivo texto formatado.

No arquivo de entrada, estarão definidos a quantidade de corpos, a quantidade de iterações, o tempo utilizado em cada iteração e as informações de cada corpo.

Em cada iteração, deverá ser armazenado em um arquivo de saída o estado de cada corpo, com informações de posição e velocidade.

O simulador deverá ter:
- Implementação de uma classe chamada Corpo, contendo os atributos:
    - Nome;
    - Massa;
    - Raio;
    - PosX;
    - PosY;
    - VelX;
    - VelY.
- Implementação de uma classe Universo, que utilize a classe Corpo para realizar os cálculos necessários para a simulação;
- Deverão ser tratados as seguintes situações:
    - Cálculo da posição dos corpos em um determinado momento;
    - Tratamento das colisões, caso ocorram;



**Formatação dos arquivos**
*Arquivo de entrada: Será utilizado para fazer a carga inicial dos corpos no universo.*
```
Primeira linha
<quantidade de corpos>;<quantidade de iterações>;<tempo entre iterações>
<Nome>;<massa>;<raio>;<PosX>;<PosY>;<VelX>;<VelY>
.
.
.
<Nome>;<massa>;<raio>;<PosX>;<PosY>;<VelX>;<VelY>
```

*Arquivo de saída: Será utilizado para guardar as informações dos cálculos em cada iteração.*
```
<quantidade de corpos>;<quantidade de iterações>
<Nome1>;<massa>;<raio>;<PosX>;<PosY>;<VelX>;<VelY>
<Nome2>;<massa>;<raio>;<PosX>;<PosY>;<VelX>;<VelY>
<Nome3>;<massa>;<raio>;<PosX>;<PosY>;<VelX>;<VelY>
************ Interacao X ************
<Nome1>;<massa>;<raio>;<PosX>;<PosY>;<VelX>;<VelY>
<Nome2>;<massa>;<raio>;<PosX>;<PosY>;<VelX>;<VelY>
<Nome3>;<massa>;<raio>;<PosX>;<PosY>;<VelX>;<VelY>
```

**Atividade Bônus**
Interface gráfica para visualização da movimentação dos corpos.
