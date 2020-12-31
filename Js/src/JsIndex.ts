import * as cs from 'csharp';

export class JsIndex {
    public canvas: cs.UnityEngine.GameObject;
    constructor(canvas: cs.UnityEngine.GameObject) {
        this.canvas = canvas;
        console.log(canvas.name);
    }
}
