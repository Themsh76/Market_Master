class Inventory {
    constructor(maxCapacity) {
        this.maxCapacity = maxCapacity;
        this.resources = {};
    }

    addResource(resource, amount) {
        if (!this.resources[resource]) {
            this.resources[resource] = 0;
        }

        const totalResources = this.getTotalResources();

        if (totalResources + amount > this.maxCapacity) {
            console.log(`You cant carry any more ${resource}.`);
            return;
        }

        this.resources[resource] += amount;
        console.log(`You collected ${amount} ${resource}. Total: ${this.resources[resource]}`);
    }

    getTotalResources() {
        let total = 0;
        for (let resource in this.resources) {
            total += this.resources[resource];
        }
        return total;
    }

    showInventory() {
        console.log("Your Inventory:");
        for (let resource in this.resources) {
            console.log(`${resource}: ${this.resources[resource]}`);
        }
    }
}

let inventory = new Inventory(100000); 

inventory.addResource('Holz', 1000);
inventory.addResource('Stein', 1000);
inventory.addResource('Eisen', 1000);
inventory.addResource('Stein-Holz', 8000);
inventory.addResource('Eisen-Stein', 8000);
inventory.addResource('Eisen-Holz', 8000);
inventory.addResource('Gold', 10000); 
inventory.addResource('Diamant', 10000);

inventory.showInventory();
        