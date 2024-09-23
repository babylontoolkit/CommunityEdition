interface ProfanityCleanerInterface {
    clean(text:string, options?:any): string;
    isProfane(text:string, options?:any):boolean;
}
declare var profanityCleaner: ProfanityCleanerInterface;