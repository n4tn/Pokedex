
class Pokemon {
    constructor() {
        this.x = random(width)
        this.y = 0
        this.r = 50
        this.vx = 0
        this.vy = 0
        this.col = color(255, 204, 0)
        this.caught = false
    }

    Move() {
        if (!this.caught) {
            let d = dist(this.x, this.y, mouseX, mouseY)
            let force = d < height / 2 ? - 10 / (d * d) : 0
            //apply the force to the existing velocity    
            this.vx += force * (mouseX - this.x)
            this.vy += force * (mouseY - this.y)
        }
        //also add some friction to take energy out of the system    
        this.vx *= 0.95
        this.vy *= 0.95
        //update the position   
        this.x += this.vx
        this.y += this.vy
    }
    Checkbounds() {
        if (this.x < 0) this.x = width
        if (this.x > width) this.x = 0
        if (this.y < 0) this.y = height
        if (this.y > height) this.y = 0
    }
    Checkcaught() {
        if (!this.caught && dist(this.x, this.y, mouseX, mouseY) < this.r) {
            this.caught = true
            let currScore = Number(document.getElementById("score").innerHTML)
            currScore++
            document.getElementById("score").innerHTML = currScore
            this.col = color(156)
        }
    }
}

let buttton
let Pokemons = []
const num_of_pokemon = 2

function setup() {
    let canvas = createCanvas(640, 480)
    canvas.parent("gameContainer")
    button = createButton('reset')

    for (let i = 0; i < num_of_pokemon; i++) {
        Pokemon[i] = new Pokemon();
    }
    button.mousePressed(resetSketch)

}
function resetSketch() {
    let canvas = createCanvas(640, 480)
    canvas.parent("gameContainer")
    for (let i = 0; i < num_of_pokemon; i++) {
        Pokemon[i] = new Pokemon();
    }
}
function draw() {
    //a nice sky blue background    
    background(180, 200, 235)
    for (let i = 0; i < num_of_pokemon; i++) {
        fill(Pokemon[i].col)
        circle(Pokemon[i].x, Pokemon[i].y, Pokemon[i].r)
        Pokemon[i].Move();
        Pokemon[i].Checkbounds();
        Pokemon[i].Checkcaught();
    }

}
