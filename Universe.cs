using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Universe
{

    double G = 6.6740184 * Math.Pow(10, -11);

    private int numberCelestialBodies;
    private int numberIterations;

    private int time;

    public Universe() { }

    /// <summary>
    /// Lê o arquivo de corpos celestes de inicialização do sistema de acordo com a quantidade máxima de corpos definida no arquivo
    /// </summary>
    /// <returns>Lista de corpos celeste</returns>
    public List<CelestialBody> ReadCelestialBodies()
    {
        List<CelestialBody> celestialBodies = new List<CelestialBody>();
        string file = "TextFile1.txt";

        // Verifica se o arquivo não existe, se não existir retorna uma quantidade vazia de corpos
        if (!File.Exists(file))
        {
            Console.WriteLine(String.Format("Arquivo {0} não existe", file));
            return celestialBodies;
        }

        string[] lines = File.ReadAllLines(file);
        int counter = 0;
        foreach (var line in lines)
        {
            // Se for a primeira linha, pega as informações iniciais de execução
            if (counter == 0)
            {
                string[] data = line.Split(";");

                numberCelestialBodies = int.Parse(data[0]);
                numberIterations = int.Parse(data[1]);
                time = int.Parse(data[1]);
            }

            if (counter > 0 && counter <= numberCelestialBodies)
            {
                CelestialBody newCelestialBody = new CelestialBody(line);
                celestialBodies.Add(newCelestialBody);
            }

            counter++;
        }

        return celestialBodies;
    }

    /// <summary>
    /// Salva no arquivo outputBodies os dados de saída
    /// </summary>
    /// <param name="output">Lista de string de saída</params>
    public void SaveCelestialBodies(List<string> output)
    {
        string file = "outputBodies.txt";

        FileStream myFile = new FileStream(file, FileMode.Open, FileAccess.Write);
        StreamWriter sw = new StreamWriter(myFile, Encoding.UTF8);


        foreach (var item in output)
        {
            sw.WriteLine(item);
        }

        sw.Close();
        myFile.Close();

    }


    /// <summary>
    /// Adiciona os dados dos corpos celestiais de uma iteração na variável de saída
    /// </summary>
    /// <param name="output">Lista de string de saída</param>
    /// <param name="bodies">Lista de corpos celestes</param>
    /// <returns>Lista de saída atualizada</returns>
    public List<string> WriteIterationBodies(List<string> output, List<CelestialBody> bodies)
    {
        foreach (var body in bodies)
        {
            output.Add(body.formatOutputFile());
        }

        return output;
    }


    /// <summary>
    /// Calcula a distancia entre dois corpos celestes usando a formula da distância Euclidiana
    /// </summary>
    /// <param name="body1">Primeiro corpo celeste</param>
    /// <param name="body2">Segundo corpo celeste</param>
    /// <returns>A distância entre os dois corpos</param>
    public double CalculateEuclidienneDistance(CelestialBody body1, CelestialBody body2)
    {
        return Math.Sqrt(Math.Pow((body1.getPosX() - body2.getPosX()), 2) + Math.Pow((body1.getPosY() - body2.getPosY()), 2));
    }


    /// <summary>
    /// Calcula e atualiza as forças de atração entre dois corpos segundo a Lei Universal Gravitacional
    /// </summary>
    /// <param name="body1">Primeiro corpo celeste</param>
    /// <param name="body2">Segundo corpo celeste</param>
    public void CalculateGravitationalForce(CelestialBody body1, CelestialBody body2)
    {

        double r = CalculateEuclidienneDistance(body1, body2);
        double F = (G * body1.getMass() * body2.getMass()) / Math.Pow(r, 2);

        double rx = (body1.getPosX() - body2.getPosX());
        double ry = (body1.getPosY() - body2.getPosY());


        double Fx = F * (rx / r);
        double Fy = F * (ry / r);


        // Acumula as forças de todos os corpos celestes
        body1.setF(body1.getF() + (F * (-1)));
        body1.setFx(body1.getFx() + (Fx * (-1)));
        body1.setFy(body1.getFy() + (Fy * (-1)));

        body2.setF(body2.getF() + (F * (1)));
        body2.setFx(body2.getFx() + (Fx * (1)));
        body2.setFy(body2.getFy() + (Fy * (1)));
    }


    /// <summary>
    /// Verifica se há a colisão entre dois corpos e atualiza a sua nova posição segundo a lei de Colisão Elástica
    /// </summary>
    /// <param name="body1">Primeiro corpo celeste</param>
    /// <param name="body2">Segundo corpo celeste</param>
    public void CalculateColision(CelestialBody body1, CelestialBody body2)
    {
        double distance = CalculateEuclidienneDistance(body1, body2);


        // Verifica se houve colisao
        if (distance < (body1.getRadius() + body2.getRadius()))
        {
            double body_1_Vx = body1.getVelX();
            double body_1_Vy = body1.getVelY();

            double body_2_Vx = body1.getVelX();
            double body_2_Vy = body1.getVelY();

            // Colisao Elastica
            body1.setVelX(body_2_Vx * (-1));
            body1.setVelY(body_2_Vy * (-1));
             
            body2.setVelX(body_1_Vx * (-1));
            body2.setVelY(body_1_Vy * (-1));

            // Calcula novamente a posição dos corpos
            CalculateForce(body1);
            CalculateForce(body2);
        }
    }


    /// <summary>
    /// Calcula a aceleração, velocidade e a nova posição do corpo celeste
    /// </summary>
    /// <param name="body">Primeiro corpo celeste</param>
    public void CalculateForce(CelestialBody body)
    {
        double Ax = body.getFx() / body.getMass();
        double Ay = body.getFy() / body.getMass();

        double Vx = body.getVelX() + (Ax * time);
        double Vy = body.getVelY() + (Ay * time);

        double Sx = body.getPosX() + (body.getVelX() * time) + ((Ax / 2) * Math.Pow(time, 2));
        double Sy = body.getPosY() + (body.getVelY() * time) + ((Ay / 2) * Math.Pow(time, 2));

        body.setPosX(Sx);
        body.setPosY(Sy);
        body.setVelX(Vx);
        body.setVelY(Vy);
    }


    /// <summary>
    /// Limpa a força de todos os corpos para a próxima iteração
    /// </summary>
    /// <param name="bodies">Lista de corpos celestes</param>
    public void CleanForces(List<CelestialBody> bodies)
    {
        foreach (var body in bodies)
        {
            body.setF(0.0f);
            body.setFx(0.0f);
            body.setFy(0.0f);
        }
    }


    /// <summary>
    /// Faz uma iteração entre todos os corpos celestes para calcular a aceleração, velocidade e posição
    /// </summary>
    /// <param name="bodies">Lista de corpos celestes</param>
    public void ApplyForceToBodies(List<CelestialBody> bodies)
    {
        foreach (var body in bodies)
        {
            CalculateForce(body);
        }
    }


    /// <summary>
    /// Faz uma iteração entre todos os corpos celestes para calcular a colisão entre eles
    /// </summary>
    /// <param name="bodies">Lista de corpos celestes</param>
    public void ApplyColisionsToBodies(List<CelestialBody> bodies)
    {

        for (var i = 0; i < bodies.Count; ++i)
        {
            for (var j = i + 1; j < bodies.Count; ++j)
            {
                CalculateColision(bodies[i], bodies[j]);
            }
        }
    }


    /// <summary>
    /// Método principal para rodar o universo
    /// </summary>
    public void Run()
    {
        List<CelestialBody> celestialBodies = ReadCelestialBodies();
        List<string> output = new List<string>();

        output.Add(String.Format("{0};{1}", celestialBodies.Count, numberIterations));

        if (celestialBodies.Count > 1)
        {
            for (int iteration = 0; iteration < numberIterations; iteration++)
            {
                output.Add(String.Format("** Interacao {0} ************", iteration));
                Console.WriteLine(String.Format("Iteração Nº {0}\n", iteration));

                for (var i = 0; i < celestialBodies.Count; ++i)
                {
                    for (var j = i + 1; j < celestialBodies.Count; ++j)
                    {
                        CalculateGravitationalForce(celestialBodies[i], celestialBodies[j]);
                    }

                    Console.WriteLine(celestialBodies[i].formatOutputFile());

                }

                ApplyForceToBodies(celestialBodies);

                output = WriteIterationBodies(output, celestialBodies);

                ApplyColisionsToBodies(celestialBodies);

                CleanForces(celestialBodies);

                Console.WriteLine("\n\n");

            }

            SaveCelestialBodies(output);
        }
    }

}