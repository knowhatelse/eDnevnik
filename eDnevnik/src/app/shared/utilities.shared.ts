import { MatDialog } from "@angular/material/dialog";

export function openDialog(dialog: MatDialog, component: any) {
    dialog.open(component, {
        width: '650px',
        height: '650px'
    });
}
