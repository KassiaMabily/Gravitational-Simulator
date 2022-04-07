<h3 align="center">
    Gravitational Simulator
</h3>

<p align="center">
    <img alt="GitHub language count" src="https://img.shields.io/github/languages/count/KassiaMabily/Gravitational-Simulator?color=%2304D361"/>
    <img alt="Repository size" src="https://img.shields.io/github/repo-size/KassiaMabily/Gravitational-Simulator" />
    <a href="https://github.com/KassiaMabily/react-template/commits/main">
        <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/KassiaMabily/Gravitational-Simulator">
    </a>
    <img alt="License" src="https://img.shields.io/badge/license-MIT-brightgreen">
</p>

<h4 align="center">
	🚧 Development 🚧
</h4>

## 💻 Overview
Simulador gravitacional 2D, que leia as informações dos corpos em um arquivo texto formatado, faça os cálculos necessários e grave os resultados em outro arquivo texto formatado.

No arquivo de entrada, estarão definidos a quantidade de corpos, a quantidade de iterações, o tempo utilizado em cada iteração e as informações de cada corpo.

Em cada iteração, deverá ser armazenado em um arquivo de saída o estado de cada corpo, com informações de posição e velocidade.

O simulador tem:
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
---

## ⚙️ How it works

```bash

# Clone this repository
$ git clone https://github.com/Gravitational-Simulator/app.git

```

## 🚀 Tech Stack

-   **[CSharp](https://docs.microsoft.com/pt-br/dotnet/csharp/)**

## Authors
<table>
    <tr>
    <td align="center">
        <p>
            <a href="#">
                <img style="border-radius: 50%" src="https://avatars3.githubusercontent.com/u/52832800?s=460&u=61b426b901b8fe02e12019b1fdb67bf0072d4f00&v=4" width="100px;" alt="Loyslene Montanari"/>
                <br />
                <sub><b>Kassia Fraga</b></sub></a><a href="#" title="Kassia Fraga">
            </a>
            <br/>

[![Linkedin Badge](https://img.shields.io/badge/-Kassia-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/kassia-fraga-178b7b1a7/)](https://www.linkedin.com/in/kassia-fraga-178b7b1a7/) 
[<img src = "https://img.shields.io/badge/@kassia.mabily-%23E4405F.svg?&style=flat-square&logo=instagram&logoColor=white">](https://www.instagram.com/kassia.mabily/)
[![Gmail Badge](https://img.shields.io/badge/-kassiafraga7@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:kassiafraga7@gmail.com)](mailto:kassiafraga7@gmail.com)
        </p>
    </td>
    </tr>
</table>

---

## 📝 Licença

Este projeto esta sob a licença [MIT](./LICENSE).
