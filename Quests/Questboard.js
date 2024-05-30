// Quest Klasse wird definiert
class Quest {
    
    constructor(name, target, reward) { //Eigenschaft der Quest
        this.name = name; // Name der Quest
        this.target = target; // Ziel der Quest
        this.progress = 0; //Fortschritt der Quest
        this.completed = false; // Quest abgeschlossen (auf nein gesetzt)
        this.reward = reward; // Belohnung der Quest
    }

    //Fortschritt der Quest wird aktualisiert
    updateProgress(amount) {
        if (!this.completed) { // Wenn Quest noch nicht abgeschlossen ist
            this.progress += amount; // fortschritt aktualisieren
            if (this.progress >= this.target) { // Wenn der Fortschritt das Ziel erreicht oder überschreitet -> Zeile unten
                this.completed = true; // Quest abgeschlossen
                console.log(`Quest ${this.name} completed! Reward: ${this.reward} XP`); // Nachricht über Name und Belohnung der Quest
            }
        }
    }
}


class QuestBoard {
  
    constructor() {
        this.quests = []; //Liste der aktuellen Quests
        this.completedQuests = []; // Liste der abgeschlossenen Quests
    }

    // Neue Quest für Quest-Board
    addQuest(quest) {
        this.quests.push(quest);
    }

    // Questboard wird aktualisiert (erneut)
    updateQuests(name, amount) {
        this.quests.forEach(quest => { 
            if (quest.name === name) { // Wenn der Name der Quest mit dem gegebenen Namen übereinstimmt-> Zeile unten
                quest.updateProgress(amount); // Aktualisieren Sie den Fortschritt der Quest
                if (quest.completed) { // Wenn die Quest abgeschlossen ist -> Zeile unten
                    this.completedQuests.push(quest); // Fügen Sie sie zur Liste der abgeschlossenen Quests hinzu
                }
            }
        });
        
        this.quests = this.quests.filter(quest => !quest.completed); // Abgeschlossene Quests aus der Liste der aktuellen Quests werden entfernt
    }

    // Diese Methode zeigt die abgeschlossenen Quests an
    showCompletedQuests() {
        console.log("Completed Quests:");
        this.completedQuests.forEach(quest => console.log(quest.name));
    }
}


let woodQuest = new Quest("Holz", 500, 100);
let stoneQuest = new Quest("Stein", 500, 100);
let ironQuest = new Quest("Eisen", 500, 100);
let Stonewood = new Quest("Stein-Holz", 8000, 2000); 
let Ironstone = new Quest("Eisen-Stein", 8000, 2000);
let Ironwood = new Quest("Eisen-Holz", 8000, 2000);
let Gold = new Quest("Gold", 10000, 3000);
let Diamond = new Quest("Diamant", 10000, 3000);
//Quests werden erstellt

let questBoard = new QuestBoard();
//Questboard wird erstellt

questBoard.addQuest(woodQuest);
questBoard.addQuest(stoneQuest);
questBoard.addQuest(ironQuest);
questBoard.addQuest(Stonewood);
questBoard.addQuest(Ironstone);
questBoard.addQuest(Ironwood);
questBoard.addQuest(Gold);
questBoard.addQuest(Diamond);
//Quest zum Board hinzufügen

questBoard.updateQuests("Holz", 500);
questBoard.updateQuests("Stein", 500);
questBoard.updateQuests("Eisen", 500);
questBoard.updateQuests("Stein-Holz", 5000);
questBoard.updateQuests("Eisen-Stein", 5000);
questBoard.updateQuests("Eisen-Holz", 5000);
//Aktualisieren der oben erzeugten Quests


questBoard.showCompletedQuests();
//Anzeigen der abgeschlossenen Quests