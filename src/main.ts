import 'phaser';
import { makeNoise2D } from "open-simplex-noise";
// import OpenSimplexNoise from 'open-simplex-noise';
import { Noise2D } from 'open-simplex-noise/lib/2d';
import { makeNoise3D, Noise3D } from 'open-simplex-noise/lib/3d';

// https://www.youtube.com/watch?v=0ZONMNUKTfU

class PlayGame extends Phaser.Scene {
	image: Phaser.GameObjects.Image;

	_algo: Noise3D;

	graphics: Phaser.GameObjects.Graphics;

	private _field: number[][];
	private _resolution: number;
	private _rows: number;
	private _cols: number;
	private _lastUpdateTime = 0;
	private _updateInterval: number = 1000 / 30; 
	private _increment = 0.3;
	private _zoff = 0;
	private _xoff = 0;
	private _yoff = 0;

	constructor() {
		super("PlayGame");
		this._resolution = 4;
	}

	preload(): void {
		this._algo = makeNoise3D(Date.now());
		
		this._cols = (this.game.config.width as number) / this._resolution;
		this._rows = (this.game.config.height as number) / this._resolution;
		this._field = new Array(this._rows + 1)
			.fill(0) 
			.map(
				() => new Array(this._cols + 1).fill(0)
			);

		
	}

	create(): void {
		this.graphics = this.add.graphics({ fillStyle: { color: 0xf0fefe } });

		
		// this.cameras.main.backgroundColor.setTo(240, 254, 254); // Setting background color to light blue using RGB values
	}

	update(time: number): void {
		if (time - this._lastUpdateTime > this._updateInterval) {
    
			this.graphics.clear();
			this.graphics = this.add.graphics({ fillStyle: { color: 0x00688B} });
			this._xoff = 0;
			this._yoff = 0;
			for (let row = 0; row <= this._rows; row++) {
				this._xoff += this._increment;

				for (let col = 0; col <= this._cols; col++) {

					this._field[row][col] =
						//Math.ceil(
						this._algo(
							this._yoff,
							this._xoff,
							this._zoff
						);
					//)
					// );
					this._yoff += this._increment;
				}
			}

			for (let row = 0; row < this._rows; row++) {
				for (let col = 0; col < this._cols; col++) {
					this.graphics.fillStyle(0x0000CD, (this._field[row][col] + 1)/2);

					this.graphics.fillPoint(
						col * this._resolution,
						row * this._resolution,
						this._resolution * 0.2
					);

					this.DrawCellLines(col, row);
				}
				
			}
			this._lastUpdateTime = time;
			this._zoff += 0.05;
		}
	}

	private DrawCellLines(column: number, row: number): void {

		this.graphics.lineStyle(1, 0xADD8E6, 1); // Set line color to green and opacity to 1

		switch (this.getIndex(row, column)) {
			case 1:
			case 14:

				this.graphics.lineBetween(
					(column + 0.5) * this._resolution,
					row * this._resolution,
					(column) * this._resolution,
					(row + 0.5) * this._resolution
				);
				break;
			case 2:
			case 13:

				this.graphics.lineBetween(
					(column + 0.5) * this._resolution,
					row * this._resolution,
					(column + 1) * this._resolution,
					(row + 0.5) * this._resolution);
				break;
			case 3:
			case 12:

				this.graphics.lineBetween(
					(column) * this._resolution,
					(row + 0.5) * this._resolution,
					(column + 1) * this._resolution,
					(row + 0.5) * this._resolution
				);
				break;
			case 4:
			case 11:

				this.graphics.lineBetween(
					(column) * this._resolution,
					(row + 0.5) * this._resolution,
					(column + 0.5) * this._resolution,
					(row + 1) * this._resolution
				);
				break;
			case 5:
			case 10:

				this.graphics.lineBetween(
					(column + 0.5) * this._resolution,
					(row) * this._resolution,
					(column + 0.5) * this._resolution,
					(row + 1) * this._resolution
				);
				break;
			case 6:

				this.graphics.lineBetween(
					(column) * this._resolution,
					(row + 0.5) * this._resolution,
					(column + 0.5) * this._resolution,
					(row + 1) * this._resolution
				);

				this.graphics.lineBetween(
					(column + 0.5) * this._resolution,
					(row ) * this._resolution,
					(column + 1) * this._resolution,
					(row + 0.5) * this._resolution
				);
				break;
			case 9:

				this.graphics.lineBetween(
					(column + 0.5) * this._resolution,
					row * this._resolution,
					(column) * this._resolution,
					(row + 0.5) * this._resolution
				);

				this.graphics.lineBetween(
					(column + 0.5) * this._resolution,
					(row + 1) * this._resolution,
					(column + 1) * this._resolution,
					(row + 0.5) * this._resolution
				);
				break;
			case 7:
			case 8:

				this.graphics.lineBetween(
					(column + 0.5) * this._resolution,
					(row + 1) * this._resolution,
					(column + 1) * this._resolution,
					(row + 0.5) * this._resolution
				);
				break;
			default:
				break;
		}


	}

	private getIndex(row: number, col: number): number {
		return Math.ceil( this._field[row][col] )* 1 +
			Math.ceil(this._field[row][col + 1]) * 2 +
			Math.ceil(this._field[row + 1][col]) * 4 +
			Math.ceil(this._field[row + 1][col + 1]) * 8;
	}

}

let configObject: Phaser.Types.Core.GameConfig = {
	scale: {
		mode: Phaser.Scale.FIT,
		autoCenter: Phaser.Scale.CENTER_BOTH,
		parent: 'thegame',
		width: 800,
		height: 600
	},
	scene: PlayGame
};

new Phaser.Game(configObject);
