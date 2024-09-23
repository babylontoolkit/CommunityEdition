declare module Colyseus {
    export  type FunctionParameters<T extends (...args: any[]) => any> = T extends (...args: infer P) => any ? P : never;
    export class EventEmitter<CallbackSignature extends (...args: any[]) => any> {
        handlers: Array<CallbackSignature>;
        register(cb: CallbackSignature, once?: boolean): this;
        invoke(...args: FunctionParameters<CallbackSignature>): void;
        invokeAsync(...args: FunctionParameters<CallbackSignature>): Promise<any[]>;
        remove(cb: CallbackSignature): void;
        clear(): void;
    }
    export enum OPERATION {
        ADD = 128,
        REPLACE = 0,
        DELETE = 64,
        DELETE_AND_ADD = 192,
        TOUCH = 1,
        CLEAR = 10
    }
    export class Room<State = any> {
        id: string;
        sessionId: string;
        name: string;
        connection: any;
        onStateChange: {
            once: (cb: (state: State) => void) => void;
            remove: (cb: (state: State) => void) => void;
            invoke: (state: State) => void;
            invokeAsync: (state: State) => Promise<any[]>;
            clear: () => void;
        } & ((this: any, cb: (state: State) => void) => EventEmitter<(state: State) => void>);
        onError: {
            once: (cb: (code: number, message?: string) => void) => void;
            remove: (cb: (code: number, message?: string) => void) => void;
            invoke: (code: number, message?: string) => void;
            invokeAsync: (code: number, message?: string) => Promise<any[]>;
            clear: () => void;
        } & ((this: any, cb: (code: number, message?: string) => void) => EventEmitter<(code: number, message?: string) => void>);
        onLeave: {
            once: (cb: (code: number) => void) => void;
            remove: (cb: (code: number) => void) => void;
            invoke: (code: number) => void;
            invokeAsync: (code: number) => Promise<any[]>;
            clear: () => void;
        } & ((this: any, cb: (code: number) => void) => EventEmitter<(code: number) => void>);
        protected onJoin: {
            once: (cb: (...args: any[]) => void | Promise<any>) => void;
            remove: (cb: (...args: any[]) => void | Promise<any>) => void;
            invoke: (...args: any[]) => void;
            invokeAsync: (...args: any[]) => Promise<any[]>;
            clear: () => void;
        } & ((this: any, cb: (...args: any[]) => void | Promise<any>) => EventEmitter<(...args: any[]) => void | Promise<any>>);
        serializerId: string;
        protected serializer: any;
        protected hasJoined: boolean;
        protected rootSchema: any;
        protected onMessageHandlers: any;
        constructor(name: string, rootSchema?: any);
        connect(endpoint: string): void;
        leave(consented?: boolean): Promise<number>;
        //onMessage<T = any>(type: "*", callback: (type: string | number | Schema, message: T) => void): any;
        //onMessage<T extends (typeof Schema & (new (...args: any[]) => any))>(type: T, callback: (message: InstanceType<T>) => void): any;
        onMessage<T = any>(type: string | number, callback: (message: T) => void): any;
        send(type: string | number, message?: any): void;
        get state(): State;
        removeAllListeners(): void;
        protected onMessageCallback(event: MessageEvent): void;
        protected setState(encodedState: number[]): void;
        protected patch(binaryPatch: number[]): void;
        private dispatchMessage;
        private destroy;
        private getMessageHandlerKey;
    }
    export class Client {
        constructor(url:string);
        create<T>(name:string, options:any):Colyseus.Room;
        joinById<T>(name:string, options:any);
    }
}