export class ColorPicker {
  public colors: string[] = [
    '#B34108',
    '#CD8C00',
    '#678A40',
    '#006954',
    '#0E5E7A',
    '#963831',
    '#219ebc',
    '#606c38',
    '#B38EC8',
    '#FF87B5',
    '#7B2CBF',
  ];

  private currentIndex: number = Math.floor(Math.random() * this.colors.length);

  getNextColor(value: string): string {
    if (['error'].includes(value.toLowerCase())) {
      return '#963831';
    }
    if (['critical'].includes(value.toLowerCase())) {
      return '#B34108';
    }
    if (['warning'].includes(value.toLowerCase())) {
      return '#CD8C00';
    }
    if (['info', 'information'].includes(value.toLowerCase())) {
      return '#678A40';
    }

    const nextColor = this.colors[this.currentIndex];
    this.currentIndex = (this.currentIndex + 1) % this.colors.length; // Increment index and loop if necessary
    return nextColor;
  }
}
