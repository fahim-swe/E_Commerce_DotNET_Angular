import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent implements OnInit {

  @Input() totallCount!: number;
  @Input() pageNumber!: number;
  @Input() pageSize!: number;

  @Output() onChanged = new EventEmitter<number>();
 
  constructor() { }

  ngOnInit(): void {
  }

  onPagerChange(event: PageEvent)
  {
    this.onChanged.emit(event.pageIndex)
  }
}
