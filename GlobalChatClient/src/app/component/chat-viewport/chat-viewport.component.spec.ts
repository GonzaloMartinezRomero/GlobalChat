import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatViewportComponent } from './chat-viewport.component';

describe('ChatViewportComponent', () => {
  let component: ChatViewportComponent;
  let fixture: ComponentFixture<ChatViewportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChatViewportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChatViewportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
