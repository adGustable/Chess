export function validateForm(whitePlayer: string, blackPlayer: string): boolean {
    if (!whitePlayer || !blackPlayer) {
        alert("Both player names must be filled.");
        return false;
    }
    if (whitePlayer === blackPlayer) {
        alert("Players cannot have the same name.");
        return false;
    }
    return true;
}