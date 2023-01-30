// Java app with user interface to roll RPG dices
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;

public class DiceRollerUI extends JFrame {
  private JButton d20Button, d12Button, d10Button, d8Button, d6Button, d4Button;
  private JLabel resultLabel;
  private Random rand = new Random();

  public DiceRollerUI() {
    super("RPG Dice Roller");
    setLayout(new FlowLayout());

    d20Button = new JButton("d20");
    add(d20Button);
    d20Button.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        resultLabel.setText("d20: " + (rand.nextInt(20) + 1));
      }
    });

    d12Button = new JButton("d12");
    add(d12Button);
    d12Button.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        resultLabel.setText("d12: " + (rand.nextInt(12) + 1));
      }
    });

    d10Button = new JButton("d10");
    add(d10Button);
    d10Button.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        resultLabel.setText("d10: " + (rand.nextInt(10) + 1));
      }
    });

    d8Button = new JButton("d8");
    add(d8Button);
    d8Button.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        resultLabel.setText("d8: " + (rand.nextInt(8) + 1));
      }
    });

    d6Button = new JButton("d6");
    add(d6Button);
    d6Button.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        resultLabel.setText("d6: " + (rand.nextInt(6) + 1));
      }
    });

    d4Button = new JButton("d4");
    add(d4Button);
    d4Button.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        resultLabel.setText("d4: " + (rand.nextInt(4) + 1));
      }
    });

    resultLabel = new JLabel("");
    add(resultLabel);
  }

  public static void main(String[] args) {
    DiceRollerUI app = new DiceRollerUI();
    app.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    app.setSize(200, 200);
    app.setVisible(true);
  }
}
