# Space Shooter
---
Проект по Визуелно Програмирање
Изработено од:
Атанас Секуловски 151054
---
### Опис 
Класична space shooter игра направена по урнек од старата Alien Invasion игра од 1980 со неколку разлики како различни типови на непријатели и надоградувања кои што играчот може да ги собере од уништените непријатели.

### Содржина
Има две "gamemodes":
##### -Standard
Играчот има 300 секунди да уништи најмногу непријатели и да собере што може повеќе надградби пред да се соочи со главниот непријател.
*За жал, моментално главниот непријател е недовршен*
##### -Infinite
Играчот нема лимит на време и може да игра без граница.
### Контроли
Стрелките се користат за движење во било која насока,Z е резервирано за пукање и Escape служи за да се паузира играта.

*Подетално објаснување на механиката на играта и на непријателите има во доленаведениот **Instructions** предел во главното мени*

![Image](https://raw.githubusercontent.com/AtanasSek/SpaceShooter/master/VizuelnoProgramiranjeGame/Screenshots/Main_Menu)
![Image](https://raw.githubusercontent.com/AtanasSek/SpaceShooter/master/VizuelnoProgramiranjeGame/Screenshots/Instructions)
---

## Опис на структурата на програмата
**Kласата `Game` ги содржи:**
- Сите објекти , листи од објекти и логика за да функционира целата игра.
- Статична метода `playMusic()`. Се повикува еднаш на почетокот на програмата.
- `startGame()`. Се повикува при рестарт или старт на играта.
- `spawnEnemies()`. Користи random integer за да одредни кој тип на непријател ќе се креира и каде ќе се креира.
- `stopGame()`. Го прикажува последниот панел со освоени поени доколку играчот изгуби или победи.
- `enemyCollisionLogic()`, `bossCollisionLogic()`, `upgradeCollisionLogic()` се справуваат со hit detection за проектили и играчот. Додатно проверуваат дали некои од тие објекти се излезени off screen за да ги избришат.
- `pauseGame()` го прикажува панелот за пауза кога е паузирана играта.
- `keyIsUp(object , KeyEventArgs)` , `keyIsDown(object, KeyEventArgs)` проверуваат кога е притиснато едно од копчињата и им задаваат вредности на booleans зададени за секое копче.
- `keyPress()` се повикува во `mainTimer_Tick()` и проверува кој boolean е позитивен за да се изврши таа команда.
- `cleanUpParticle()` ги брише сите објекти во листата spaceDebris кои што ќе излезат вон екранот на корисникот.
- `mainTimer_Tick(object, EventArgs)` ги повикува методите `enemyCollisionLogic()`, `bossCollisionLogic()`,  `upgradeCollisionLogic()` , `keyPress()`, `cleanUpParticle()` во интервал од 10мс.
- `enemyTimer_Tick(object, EventArgs)` се грижи за креирање на нови непријатели, започнува со интервал од 3000мс и после кога ќе се повика следниот интервал може да биде помеѓу 400мс и 1250мс.
- `enemyProjectileTimer_Tick(object, EventArgs)` служи за да се одреди кога ќе пукаат непријателите во интервал од 2000мс до 4000мс. Како нуспојава на оваа имплементација , сите непријатели пукаат во синхронизирано.
- `bossTimer_Tick(object, EventArgs)` одбројува до моментот кога ќе се креира главниот непријател.
- `particleTimer_Tick(object, EventArgs)` одредува кога ќе се креира објект од `SpaceDebris` класата.
- `Form1_Paint(object, PaintEventArgs)` се справува со генерирање на графичките елементи на играта и истовремено движењето на објектите од класите `Enemy`, `SpaceDebris`, `Boss`, `Projectile`.

**Класата `Spaceship` е класата од која што класите `Enemy` , `Boss`, `Player`,'ShipUpgrade' ги наследуваат следниве методи:**
- `Draw(Graphics)`. Ги црта графичките елементи на објектот.
- `Damage(Projectile)`. Одзема живот на објектот базирано од тоа колку *damage* има одреден проектил.
- `PureDamage(int)`. Одзема живот на објектот директно.
- `virtual Projectile Shoot()`. Креира објект од класата `Projectile`, му задава вредности за тој проектил и го враќа во return.
- `virtual bool isHit(Projectile)`. Проверува дали hitbox-от на тој елемент доаѓа во контакт со проектил.

**`Spaceship` ги зодржи следниве променливи:**
- `Point center`. Служи за одредување на местоположба на објектот.
- `int width` и `int height`. Висина и ширина на објектот кога ќе се црта.
- `Bitmap sprite`. Битмапа од png од кој што ќе се црта објектот.
- `Rectangle hitbox`. Служи за да му се зададе hitbox на објектот. `Rectangle` класата содржи метода `IntersectsWith(Rectangle)` која што понатаму се користи за hit detection.
- `int hitpoints`. Живот на објектот.
- `int speed`. Брзината на движење.
- `int projectileDamage`. Колку *damage* прави проектилот генериран од тој објект преку методата `Shoot()`.
- `float shootCooldown`. Колку ќе чека играчот(во милисекунди) додека не испука следен проектил.
- `Stopwatch CooldownTimer`. Служи за одбројување до следниот проектил.

**Класата `Boss` е недовршена и содржи само конструктор и метода `Move()` која што служи за вертикално движење**

**Класата `Enemy` се состои од конструктор и од метода `Move()`. Во конструкторот се задаваат вредности зависи од каков тип на непријател бил повикан со `public enum Type { Regular, Tanky, Shooter }` во класата `Game`**

**Класата `Player` содржи enum playerControls(служи за одбирање насока на движење. Ги содржи методите `Shoot()` , `isHit(Enemy)` ,`isHit(Boss)` , `isHit(ShipUpgrade)`, `setUpgrade(ShipUpgrade)` ,`DrawHud(Graphics)` , `isHit(Projectile)` , `Move(playerControls)`:**
- Варијациите на `isHit()` методата се самообјасниви преку аргументот кој што го примаат.
- `setUpgrade(ShipUpgrade)` ги поставува надоградите кој што играчот ќе ги собере на полето.
- `DrawHud(Graphics)` го црта Heads Up Display-от на играчот.
``` 
public void DrawHUD(Graphics g)
        {
            int distance = 0;
            if (hitpoints >= 6)
            {
                g.DrawImage(base.sprite, Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Bottom - height, base.width, base.height);
                distance = width + 20;
                SolidBrush brush = new SolidBrush(Color.White);
                FontFamily ff = new FontFamily("Courier New"); 
                System.Drawing.Font font = new System.Drawing.Font(ff, 30);
                g.DrawString("X"+hitpoints,font,brush, new Point(0 + width, Screen.PrimaryScreen.Bounds.Bottom - height));
            }
            else
            {
                for (int i = 0; i < hitpoints; i++)
                {
                    g.DrawImage(base.sprite, Screen.PrimaryScreen.Bounds.Left + distance, Screen.PrimaryScreen.Bounds.Bottom - height, base.width, base.height);
                    distance += (width + 20);
                }
            }
        }
```

**Класата `Projectile` ги содржи аргументите:**
- `Point firingPoint`. Следи од каде бил испукан проектилот.
- `int projectileVelocity`.
- `Rectangle projectileHitbox`.
- `int projectileWidth`.
- `int projectileHeight`.
- `int projectileDamage`.
- `bool isEnemyProjectile`. Следи дали проектилот бил испукан од непријател или не. Служи за hit detection во `CollisionLogic` методите во класата `Game`.

**Методите:**
- `Draw(Graphics)`.
- `Move()`. Проверува дали проектилот е испукан од непријател. Доколку е се движи надоле, а доколку не е, се движи нагоре.

**Класата `ShipUpgrade` ги содржи аргументите:**
- `float projectileCooldown`. За колку ќе се намали cooldown-ot на проектилот кој што го пука играчот во милисекунди.
- `int fallingSpeed`. Брзина на движење надоле.
- `bool assigned`. Следи дали random integer-от ги има исполнето условите за создавање на објект.

**Класата `SpaceDebris` служи само за креирање на мали бели точки во позадината кои што создаваат илузија на движење за играчот.**