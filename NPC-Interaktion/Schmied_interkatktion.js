class Spieler {
    constructor(name, money) {
        this.name = name;
        this.money = money;
    }

    getMoney() {
        return this.money;
    }

    setMoney(amount) {
        this.money = amount;
    }
}

class Schmied {
    constructor(name, requiredMoney) {
        this.name = name;
        this.requiredMoney = requiredMoney;
    }

    interact(player) {
        if (player.getMoney() >= this.requiredMoney) {
            document.getElementById("output").innerText = `${this.name}: Du hast genug Geld.`;
        } else {
            document.getElementById("output").innerText = `${this.name}: Du hast nicht genug Geld.`;
        }
    }
}

const player = new Player("Spieler", 50);
const npc = new NPC("Händler", 30);

function interactWithNPC(npc, player) {
    npc.interact(player);
}