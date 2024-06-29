import 'phaser'

export default class MainMenu extends Phaser.Scene {
    
    private keys!: Phaser.Types.Input.Keyboard.CursorKeys;

    constructor() {
        super('MainMenu')
    }

    preload(): void {
        //TODO: need to load the assets
        //sthis.keys = this.input.keyboard.createCursorKeys();
    }

    create(): void {
        // TODO: need to create the main menu


    }

    update(): void {
        // TODO: need to update the main menu
    }


}