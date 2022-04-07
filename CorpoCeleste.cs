using System;


class CelestialBody {
    private string name;

    private double posX;
    private double posY;
    private float mass;
    private float radius;
    private double velX;
    private double velY;


    public CelestialBody(string n, float x, float y, float m, float r, float vx, float vy) {
        name = n;
        posX = x;
        posY = y;
        mass = m;
        radius = r;
        velX = vx;
        velY = vy;
    }

    public CelestialBody(string line) {
        string[] data = line.Split(";");

        name = float.Parse(data[0]);
        mass = float.Parse(data[1]);
        radius = double.Parse(data[2]);
        posX = double.Parse(data[3]);
        posY = double.Parse(data[4]);
        velX = double.Parse(data[5]);
        velY = double.Parse(data[6]);
    }

    public float getMass() {
        return mass;
    }

    public float getPosX() {
        return posX;
    }

    public float getPosY() {
        return posY;
    }

    public float getVelX() {
        return velX;
    }

    public float getVelY() {
        return velY;
    }

    public void setPosX(double x) {
        posX = x;
    }

    public void setPosY(double y) {
        posY = y;
    }

    public void setVelX(double x) {
        velX = x;
    }

    public void setVelY(double y) {
        velY = y;
    }

    public void formatOutputFile() {
        return String.Format("{0};{1};{2};{3};{4};{5};{5}", name, mass, radius, posX, posY, velX, velY);
    }

    public void print() {
        Console.WriteLine(string.Format("Posição X: {0}\nPosição Y: {1}\nMassa: {2}", posX, posY, mass));
    }
    
}